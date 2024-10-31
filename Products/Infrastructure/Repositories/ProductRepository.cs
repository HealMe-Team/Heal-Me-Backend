using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Repositories;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealMeAppBackend.API.Products.Infrastructure.Repositories
{
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
    }
}
