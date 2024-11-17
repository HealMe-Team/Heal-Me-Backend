using HealMeAppBackend.API.Authentication.Application.OutboundServices;
using HealMeAppBackend.API.Authentication.Infrastructure.Hashing.BCrypt.Services;
using HealMeAppBackend.API.Authentication.Infrastructure.Tokens.JWT.Configuration;
using HealMeAppBackend.API.Authentication.Infrastructure.Tokens.JWT.Services;
using HealMeAppBackend.API.Doctors.Application.Internal;
using HealMeAppBackend.API.Doctors.Domain.Repositories;
using HealMeAppBackend.API.Doctors.Domain.Services;
using HealMeAppBackend.API.Doctors.Infrastructure.Repositories;

using HealMeAppBackend.API.Hospitals.Application.Internal;
using HealMeAppBackend.API.Hospitals.Domain.Repositories;
using HealMeAppBackend.API.Hospitals.Domain.Services;
using HealMeAppBackend.API.Hospitals.Infrastructure.Repositories;

using HealMeAppBackend.API.Products.Application.Internal;
using HealMeAppBackend.API.Products.Domain.Repositories;
using HealMeAppBackend.API.Products.Domain.Services;
using HealMeAppBackend.API.Products.Infrastructure.Repositories;

using HealMeAppBackend.API.Shared.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using HealMeAppBackend.API.Shared.Interfaces.ASP.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
// add configuration
var configuration = builder.Configuration;

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenSettings:Secret"])),
            ClockSkew = TimeSpan.Zero // Para validación precisa de expiración
        };
    });

builder.Services.AddAuthorization();


//builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                      Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                      Example: 'Bearer 12345abcdef'<br /> <br />",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection string is not set.");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
        });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<IHashingService, HashingService>();

// Doctors Bounded Context Injection Configuration
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorCommandService, DoctorCommandService>();
builder.Services.AddScoped<IDoctorQueryService, DoctorQueryService>();

// Hospitals Bounded Context Injection Configuration
builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
builder.Services.AddScoped<IHospitalCommandService, HospitalCommandService>();
builder.Services.AddScoped<IHospitalQueryService, HospitalQueryService>();

// Products Bounded Context Injection Configuration
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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



