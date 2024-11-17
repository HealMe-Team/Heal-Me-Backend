using HealMeAppBackend.API.Products.Domain.Model.Commands;

namespace HealMeAppBackend.API.Products.Domain.Model.Aggregates
{
    /// <summary>
    ///     Product Aggregate
    /// </summary>
    /// <remarks>
    ///     This class represents the Product aggregate. It is used to store the details of a product.
    /// </remarks>
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; } // Precio del producto
        public int Rating { get; private set; } // Calificación del producto (1 a 5 estrellas)

        public Product()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Price = 0; // Precio por defecto
            this.Rating = 0; // Calificación por defecto
        }

        public Product(string name, string description, decimal price, int rating)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Rating = rating;
        }

        ///<summary>
        ///    Constructor for the Product aggregate.
        ///</summary>
        ///<remarks>
        ///    The constructor is the command handler for the CreateProductCommand.
        ///</remarks>
        public Product(CreateProductCommand command)
        {
            this.Name = command.Name;
            this.Description = command.Description;
            this.Price = command.Price;
            this.Rating = command.Rating;
        }
    }
}
