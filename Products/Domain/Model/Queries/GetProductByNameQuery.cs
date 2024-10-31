namespace HealMeAppBackend.API.Products.Domain.Model.Queries
{
    /// <summary>
    ///     Query to get a product by name.
    /// </summary>
    /// <param name="Name">The name of the product.</param>
    public record GetProductByNameQuery(string Name);
}
