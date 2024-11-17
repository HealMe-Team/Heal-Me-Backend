using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Products.Infrastructure.Repositories
{
     /// <summary>
    ///     Repository implementation for managing products in the database.
    /// </summary>
    /// <remarks>
    ///     Provides methods to query and manage product data, including finding products
    ///     by name, ID, and rating.
    /// </remarks>
    public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
    {
        /// <inheritdoc />
        public async Task<Product?> FindByNameAsync(string name)
        {
            return await context.Set<Product>().FirstOrDefaultAsync(p => p.Name == name);
        }

        /// <inheritdoc />
        public async Task<Product?> FindByIdAsync(int id)
        {
            return await context.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> FindByRatingAsync(int rating)
        {
            return await context.Set<Product>()
                .Where(d => d.Rating == rating)
                .ToListAsync();
        }

    }
}
