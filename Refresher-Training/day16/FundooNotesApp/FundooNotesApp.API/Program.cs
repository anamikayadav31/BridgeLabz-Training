using System.Text;
using FundooNotesApp.BusinessLayer.Events;
using FundooNotesApp.BusinessLayer.Helpers;
using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;
using FundooNotesApp.RepositoryLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// ---------- 0. Logging (NLog) ----------
// Swap out the default .NET logging for NLog, which reads its rules
// from nlog.config (where to write logs, and at what detail level).
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// ---------- 1. Database ----------
// Points EF Core at SQL Server, using the connection string from
// appsettings.json ("FundooDbConnection").
builder.Services.AddDbContext<FundooContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FundooDbConnection")));

// ---------- 2. Dependency Injection for our layers ----------
// "AddScoped" = one fresh instance of the class per web request.
builder.Services.AddScoped<IUserRL, UserRL>();   // RepositoryLayer
builder.Services.AddScoped<IUserBL, UserBL>();   // BusinessLayer
builder.Services.AddScoped<INoteRL, NoteRL>();                    // RepositoryLayer (Notes)
builder.Services.AddScoped<INoteCommandBL, NoteCommandBL>();      // BusinessLayer (Notes - writes)
builder.Services.AddScoped<INoteQueryBL, NoteQueryBL>();          // BusinessLayer (Notes - reads)
builder.Services.AddScoped<ITagRL, TagRL>();                      // RepositoryLayer (Tags)
builder.Services.AddScoped<ITagBL, TagBL>();                      // BusinessLayer (Tags)

// ---------- 2b. Pub-Sub event publisher ----------
// AddSingleton (not AddScoped!) - we want ONE shared publisher for the
// whole app's lifetime, so every request's NoteCommandBL is publishing
// to (and every subscriber is listening on) the exact same instance.
builder.Services.AddSingleton<INoteEventPublisher, NoteEventPublisher>();
builder.Services.AddSingleton<NoteActivityLogger>();

// ---------- 3. JWT setup ----------
// The secret key used to SIGN and later VERIFY tokens. Keep this out
// of source control in a real project (use user-secrets or env vars).
string jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"]!;
builder.Services.AddSingleton(new TokenGenerator(jwtSecretKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // This is where incoming "Authorization: Bearer <token>" headers
    // get checked against the same secret key we used to sign them.
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
    };
});

builder.Services.AddAuthorization();

// ---------- 4. Controllers + Swagger ----------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fundoo Notes App API", Version = "v1" });

    // Adds a padlock icon + "Authorize" button in Swagger UI so we can
    // paste in a JWT and test protected endpoints straight from the browser.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter: Bearer {your JWT token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ---------- 4b. Wire up our pub-sub subscriber ----------
// This is the ONE place NoteActivityLogger and the publisher ever meet
// each other - after this line, NoteCommandBL can publish events with
// zero knowledge that a logger is listening on the other end.
var eventPublisher = app.Services.GetRequiredService<INoteEventPublisher>();
var noteActivityLogger = app.Services.GetRequiredService<NoteActivityLogger>();
noteActivityLogger.SubscribeTo(eventPublisher);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Visit /swagger to try out every endpoint.
}

app.UseHttpsRedirection();

// Order matters: check WHO you are (Authentication) before checking
// WHAT you're allowed to do (Authorization).
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
