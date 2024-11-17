using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Model.Queries;
using HealMeAppBackend.API.Products.Domain.Repositories;
using HealMeAppBackend.API.Products.Domain.Services;
using HealMeAppBackend.API.Products.Infrastructure.Repositories;
using HealMeAppBackend.API.Shared.Domain.Repositories;

namespace HealMeAppBackend.API.Products.Application.Internal
{
    /// <summary>
    ///     Product query service.
    /// </summary>
    /// <remarks>
    ///     This class implements the basic operations for a product query service.
    /// </remarks>
    /// <param name="productRepository">The ProductRepository instance.</param>
    public class ProductQueryService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductQueryService
    {
        /// <inheritdoc />
        public async Task<Product?> Handle(GetProductByIdQuery query)
        {
            return await productRepository.FindByIdAsync(query.Id);
        }

        /// <inheritdoc />
        public async Task<Product?> Handle(GetProductByNameQuery query)
        {
            return await productRepository.FindByNameAsync(query.Name);
        }

        public async Task<IEnumerable<Product>> Handle(GetProductByRatingQuery query)
        {
            return await productRepository.FindByRatingAsync(query.Rating);
        }

    }
}
