using HealMeAppBackend.API.Doctors.Domain.Model.Aggregates;
using HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
     /// <summary>
    ///     Provides extension methods for string manipulation, such as converting
    ///     to snake_case and pluralizing strings.
    /// </summary>
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la entidad Doctor
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Doctor>().Property(d => d.Name).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.Description).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.Rating).IsRequired();

            // Configuración para la entidad Hospital
            modelBuilder.Entity<Hospital>().HasKey(h => h.Id);
            modelBuilder.Entity<Hospital>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Hospital>().Property(h => h.Name).IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.Description).IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.Location).IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.Rating).IsRequired();

            // Configuración para la entidad Product
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Rating).IsRequired();

            modelBuilder.UseSnakeCaseNamingConvention();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

