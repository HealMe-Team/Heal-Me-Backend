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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

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

app.UseAuthorization();

app.MapControllers();

app.Run();
