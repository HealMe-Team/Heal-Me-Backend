using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Model.Commands;
using HealMeAppBackend.API.Products.Domain.Repositories;
using HealMeAppBackend.API.Products.Domain.Services;
using HealMeAppBackend.API.Shared.Domain.Repositories;
using System;

namespace HealMeAppBackend.API.Products.Application.Internal
{
    /// <summary>
    ///     Product command service.
    /// </summary>
    /// <remarks>
    ///     This class implements the basic operations for a product command service.
    /// </remarks>
    public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
    {
        /// <inheritdoc />
        public async Task<Product?> Handle(CreateProductCommand command)
        {
            var existingProduct = await productRepository.FindByNameAsync(command.Name);

            if (existingProduct != null) throw new Exception("Product already exists");

            var product = new Product(command);

            try
            {
                await productRepository.AddAsync(product);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return product;
        }
    }
}
