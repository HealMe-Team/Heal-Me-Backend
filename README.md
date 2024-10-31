### Project Documentation

#### Description
This project is an API for the HealMeAppBackend application, which manages doctors, hospitals, and products.

#### Technologies Used
- **Language**: C#
- **Framework**: ASP.NET Core
- **Database**: MySQL
- **ORM**: Entity Framework Core

#### Project Configuration
- **Configuration File**: `launchSettings.json`
- **Development Environment**: `Development`
- **Application URL**: `http://localhost:5178`

#### Endpoints

##### Doctors
- **GET** `/api/doctors` - Retrieves the list of doctors.
- **POST** `/api/doctors` - Creates a new doctor.
- **GET** `/api/doctors/{id}` - Retrieves a doctor by ID.
- **PUT** `/api/doctors/{id}` - Updates a doctor by ID.
- **DELETE** `/api/doctors/{id}` - Deletes a doctor by ID.

##### Hospitals
- **GET** `/api/hospitals` - Retrieves the list of hospitals.
- **POST** `/api/hospitals` - Creates a new hospital.
- **GET** `/api/hospitals/{id}` - Retrieves a hospital by ID.
- **PUT** `/api/hospitals/{id}` - Updates a hospital by ID.
- **DELETE** `/api/hospitals/{id}` - Deletes a hospital by ID.

##### Products
- **GET** `/api/products` - Retrieves the list of products.
- **POST** `/api/products` - Creates a new product.
- **GET** `/api/products/{id}` - Retrieves a product by ID.
- **PUT** `/api/products/{id}` - Updates a product by ID.
- **DELETE** `/api/products/{id}` - Deletes a product by ID.

#### Database Configuration
The database connection is configured in the `Program.cs` file using the `DefaultConnection` connection string.

#### Dependency Injection
Dependencies are configured in the `Program.cs` file using `AddScoped` for the repositories and services of each bounded context (doctors, hospitals, products).

### Database Configuration in `Program.cs`
```csharp
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
```

### Dependency Injection in `Program.cs`
```csharp
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
```

This structure provides a foundation for documenting your project. You can expand it with more specific details as needed.
