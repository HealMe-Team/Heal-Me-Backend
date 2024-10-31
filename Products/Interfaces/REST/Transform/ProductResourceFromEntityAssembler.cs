using HealMeAppBackend.API.Products.Domain.Model.Aggregates;
using HealMeAppBackend.API.Products.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Products.Interfaces.REST.Transform
{
    public static class ProductResourceFromEntityAssembler
    {
        public static ProductResource ToResourceFromEntity(Product entity) =>
            new ProductResource(entity.Id, entity.Name, entity.Description, entity.Price, entity.Rating);
    }
}
