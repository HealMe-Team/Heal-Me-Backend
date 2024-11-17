using HealMeAppBackend.API.Products.Domain.Model.Commands;
using HealMeAppBackend.API.Products.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Products.Interfaces.REST.Transform
{
     /// <summary>
    ///     Repository implementation for managing products in the database.
    /// </summary>
    /// <remarks>
    ///     Provides methods to query and manage product data, including finding products
    ///     by name, ID, and rating.
    /// </remarks>
    public static class CreateProductCommandFromResourceAssembler
    {
        public static CreateProductCommand ToCommandFromResource(CreateProductResource resource) =>
            new CreateProductCommand(resource.Name, resource.Description, resource.Price, resource.Rating);
    }
}
