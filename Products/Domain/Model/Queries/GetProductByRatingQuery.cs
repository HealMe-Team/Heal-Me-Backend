namespace HealMeAppBackend.API.Products.Domain.Model.Queries
{
    /// <summary>
    /// Query to get Product by their rating.
    /// </summary>
    /// <param name="Rating">The rating of the Product.</param>
    public record GetProductByRatingQuery(int Rating);
}
