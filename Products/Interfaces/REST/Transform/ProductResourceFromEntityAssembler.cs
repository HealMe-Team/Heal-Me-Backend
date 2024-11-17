using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Products.Interfaces.REST.Transform
{
     /// <summary>
    ///     Assembler for converting a <see cref="Product"/> entity to a <see cref="ProductResource"/>.
    /// </summary>
    /// <remarks>
    ///     Provides utility methods to map domain entities to REST resource representations.
    /// </remarks>
    public static class ProductResourceFromEntityAssembler
    {
        public static ProductResource ToResourceFromEntity(Product entity) =>
            new ProductResource(entity.Id, entity.Name, entity.Description, entity.Price, entity.Rating);
    }
}
