using System.Text;
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

// BEGINNER NOTE ON MICROSERVICES: this is now a completely independent,
// separately-runnable web application - it has its own port, its own
// database, and could be deployed on its own server without the Notes
// Service knowing or caring. This service's ONE job is managing users:
// register, login, forgot/reset password, and issuing JWT tokens.
var builder = WebApplication.CreateBuilder(args);

// ---------- 1. Database - this service's OWN database ----------
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserServiceDbConnection")));

// ---------- 2. Dependency Injection ----------
builder.Services.AddScoped<IUserRL, UserRL>();
builder.Services.AddScoped<IUserBL, UserBL>();

// ---------- 3. JWT setup - THIS service is the one that ISSUES tokens ----------
// The secret key here must be the EXACT SAME string configured in the
// Notes Service's appsettings.json - that shared secret is the whole
// mechanism that lets two independent services trust the same token
// without ever calling each other over the network to check it.
string jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"]!;
builder.Services.AddSingleton(new TokenGenerator(jwtSecretKey));

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
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fundoo Notes - User Service", Version = "v1" });

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
