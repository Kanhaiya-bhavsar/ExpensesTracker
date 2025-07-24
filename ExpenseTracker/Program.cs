using System.Text;
using ExpenseTracker.Application.Extensions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure;
using ExpenseTracker.Infrastructure.Extensions;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using ExpenseTracker.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ---------------- CORS ----------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ---------------- Controllers ----------------
builder.Services.AddControllers();

// ---------------- Swagger (With JWT) ----------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and the JWT token.\n\nExample: Bearer abc123"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// ---------------- Application & Infrastructure ----------------
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// ---------------- Identity ----------------
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("ExpenseTracker")
    .AddEntityFrameworkStores<ExpenseTrackerDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// ---------------- JWT Authentication ----------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// ---------------- Cloudinary ----------------

builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));


// Optional: Register Cloudinary client directly if needed (not required if using PhotoService only)
// builder.Services.AddSingleton(sp =>
// {
//     var config = sp.GetRequiredService<IOptions<CloudinarySettings>>().Value;
//     var account = new CloudinaryDotNet.Account(config.CloudName, config.ApiKey, config.ApiSecret);
//     return new CloudinaryDotNet.Cloudinary(account);
// });

var app = builder.Build();

// ---------------- Middleware ----------------
app.UseCors("AllowFrontendApp");

if (app.Environment.IsDevelopment())
{
    try
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Swagger failed to start: " + ex.Message);
        throw;
    }
}

app.UseHttpsRedirection();

app.UseAuthentication(); // 🔐 JWT
app.UseAuthorization();

app.MapControllers();

app.Run();
