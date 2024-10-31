namespace HealMeAppBackend.API.Products.Domain.Model.Queries
{
    /// <summary>
    ///     Query to get a product by its ID.
    /// </summary>
    /// <param name="Id">The ID of the product.</param>
    public record GetProductByIdQuery(int Id);
}
