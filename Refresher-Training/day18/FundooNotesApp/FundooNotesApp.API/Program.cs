using System.Text;
using FundooNotesApp.API.BackgroundServices;
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

var builder = WebApplication.CreateBuilder(args);

// ---------- 1. Database ----------
// Points EF Core at SQL Server, using the connection string from
// appsettings.json ("FundooDbConnection").
builder.Services.AddDbContext<FundooContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FundooDbConnection")));

// ---------- 2. Dependency Injection for our layers ----------
// "AddScoped" = one fresh instance of the class per web request.
builder.Services.AddScoped<IUserRL, UserRL>();   // RepositoryLayer
builder.Services.AddScoped<IUserBL, UserBL>();   // BusinessLayer
builder.Services.AddScoped<INoteRL, NoteRL>();   // RepositoryLayer (Notes)
builder.Services.AddScoped<INoteBL, NoteBL>();   // BusinessLayer (Notes)
builder.Services.AddScoped<ITagRL, TagRL>();     // RepositoryLayer (Tags)
builder.Services.AddScoped<ITagBL, TagBL>();     // BusinessLayer (Tags)
builder.Services.AddScoped<IReminderRL, ReminderRL>();   // RepositoryLayer (Reminders)
builder.Services.AddScoped<IReminderBL, ReminderBL>();   // BusinessLayer (Reminders)

// ---------- 2b. RabbitMQ email queue ----------
// Producer side: UserBL depends on IEmailQueuePublisher and calls
// Publish() - it has no idea RabbitMQ is even involved.
builder.Services.AddSingleton<IEmailQueuePublisher>(new EmailQueuePublisher(
    builder.Configuration["RabbitMQSettings:HostName"]!,
    builder.Configuration["RabbitMQSettings:QueueName"]!
));

// Consumer side: a background service that stays alive for the whole
// lifetime of the API, listening on the same queue and actually
// sending the emails.
builder.Services.AddHostedService<EmailQueueConsumer>();

// ---------- 2c. Redis reset-token cache ----------
// UserBL depends on IResetTokenCache, not Redis directly - same
// "hide the real thing behind an interface" idea as the email queue.
builder.Services.AddSingleton<IResetTokenCache>(new RedisResetTokenCache(
    builder.Configuration["RedisSettings:ConnectionString"]!
));

// ---------- 2d. Reminder scanner ----------
// Checks every minute for due reminders and pushes an email onto the
// same RabbitMQ queue - see ReminderScannerService for the details.
builder.Services.AddHostedService<ReminderScannerService>();

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
