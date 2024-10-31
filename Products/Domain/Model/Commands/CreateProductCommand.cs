namespace HealMeAppBackend.API.Products.Domain.Model.Commands
{
    /// <summary>
    ///     Command to create a product.
    /// </summary>
    /// <param name="Name">The product's name.</param>
    /// <param name="Description">The product's description.</param>
    /// <param name="Price">The product's price.</param>
    /// <param name="Rating">The product's rating, from 1 to 5 stars.</param>
    public record CreateProductCommand(string Name, string Description, decimal Price, int Rating);
}
