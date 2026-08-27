using System.Text;
using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;
using FundooNotesApp.RepositoryLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

// BEGINNER NOTE ON MICROSERVICES: this service handles Notes, Tags,
// and Reminders - completely separate from the User Service, with its
// own database and its own port. It has NEVER heard of UserEntity or
// UserDbContext at all.
//
// So how does [Authorize] still work here if this service never logs
// anyone in? Because JWTs are STATELESS - as long as this service is
// given the same secret key the User Service used to SIGN the token,
// it can independently VERIFY that token is genuine, with zero network
// calls back to the User Service. This is one of the most common
// patterns for authentication across microservices.
var builder = WebApplication.CreateBuilder(args);

// ---------- 1. Database - this service's OWN database ----------
builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesServiceDbConnection")));

// ---------- 2. Dependency Injection ----------
builder.Services.AddScoped<INoteRL, NoteRL>();
builder.Services.AddScoped<INoteBL, NoteBL>();
builder.Services.AddScoped<ITagRL, TagRL>();
builder.Services.AddScoped<ITagBL, TagBL>();
builder.Services.AddScoped<IReminderRL, ReminderRL>();
builder.Services.AddScoped<IReminderBL, ReminderBL>();

// ---------- 3. JWT setup - this service only VALIDATES, never issues ----------
// Notice there's no TokenGenerator registered here at all - this
// service has no way to create a token, only to check one it's handed.
string jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
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
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fundoo Notes - Notes Service", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Paste a token from the User Service: Bearer {token}",
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
