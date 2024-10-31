using HealMeAppBackend.API.Products.Domain.Model.Commands;
using HealMeAppBackend.API.Products.Interfaces.REST.Resources;

namespace HealMeAppBackend.API.Products.Interfaces.REST.Transform
{
    public static class CreateProductCommandFromResourceAssembler
    {
        public static CreateProductCommand ToCommandFromResource(CreateProductResource resource) =>
            new CreateProductCommand(resource.Name, resource.Description, resource.Price, resource.Rating);
    }
}
