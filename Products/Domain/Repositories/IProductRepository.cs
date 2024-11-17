using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Shared.Domain.Repositories;

namespace HealMeAppBackend.API.Products.Domain.Repositories
{
    /// <summary>
    ///     The Product repository contract.
    /// </summary>
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        ///     Find a product by its ID.
        /// </summary>
        /// <param name="id">The product's ID.</param>
        /// <returns>
        ///     The product object if found, null otherwise.
        /// </returns>
        Task<Product?> FindByIdAsync(int id);

        /// <summary>
        ///     Find a product by its name.
        /// </summary>
        /// <param name="name">The product's name.</param>
        /// <returns>
        ///     The product object if found, null otherwise.
        /// </returns>
        Task<Product?> FindByNameAsync(string name);

        Task<IEnumerable<Product>> FindByRatingAsync(int rating);

    }
}
