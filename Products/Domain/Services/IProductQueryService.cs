using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Model.Queries;

namespace HealMeAppBackend.API.Products.Domain.Services
{
    /// <summary>
    ///     Interface for the ProductQueryService
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for the ProductQueryService.
    /// </remarks>
    public interface IProductQueryService
    {
        /// <summary>
        ///     Handle the GetProductByIdQuery
        /// </summary>
        /// <remarks>
        ///     This method handles the GetProductByIdQuery. It returns the product with the given id.
        /// </remarks>
        /// <param name="query">The GetProductByIdQuery</param>
        /// <returns>The Product object if found, or null otherwise</returns>
        Task<Product?> Handle(GetProductByIdQuery query);

        /// <summary>
        ///     Handle the GetProductByNameQuery
        /// </summary>
        /// <remarks>
        ///     This method handles the GetProductByNameQuery. It returns the product with the given name.
        /// </remarks>
        /// <param name="query">The GetProductByNameQuery</param>
        /// <returns>The Product object if found, or null otherwise</returns>
        Task<Product?> Handle(GetProductByNameQuery query);

        Task<IEnumerable<Product>> Handle(GetProductByRatingQuery query);

    }
}
