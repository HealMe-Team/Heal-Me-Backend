﻿namespace HealMeAppBackend.API.Products.Interfaces.REST.Resources
{
    /// <summary>
    ///    Represents the data provided by the client to create a product.
    /// </summary>
    /// <param name="Name">The product's name</param>
    /// <param name="Description">The product's description</param>
    /// <param name="Price">The product's price</param>
    /// <param name="Rating">The product's rating (1 to 5 stars)</param>
    public record CreateProductResource(string Name, string Description, decimal Price, int Rating);
}
