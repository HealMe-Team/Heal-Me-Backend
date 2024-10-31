using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Domain.Model.Commands;

namespace HealMeAppBackend.API.Products.Domain.Services
{
    /// <summary>
    ///     Interface for the ProductCommandService
    /// </summary>
    /// <remarks>
    ///     This interface defines the basic operations for the ProductCommandService.
    /// </remarks>
    public interface IProductCommandService
    {
        /// <summary>
        ///     Handle the CreateProductCommand.
        /// </summary>
        /// <remarks>
        ///     This method handles the CreateProductCommand. It checks if the product already exists, and if not, creates it.
        /// </remarks>
        /// <param name="command">CreateProductCommand</param>
        /// <returns>The Product object if created, or null otherwise</returns>
        /// <exception cref="Exception"></exception>
        Task<Product?> Handle(CreateProductCommand command);
    }
}
