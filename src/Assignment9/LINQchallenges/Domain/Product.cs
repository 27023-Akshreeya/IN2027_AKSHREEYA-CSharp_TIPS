namespace LINQchallenges.Domain
{
    /// <summary>
    /// Represents a product entity in the domain model.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        /// <value>
        /// The unique identifier for the product.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        /// <value>
        /// The unit price of the product.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category classification of the product.
        /// </summary>
        /// <value>
        /// The category classification of the product.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Returns a comma-separated string representation of the product details.
        /// </summary>
        /// <returns>A string containing the product ID, name, and price.</returns>
        public override string ToString()
        {
            return $"{this.ProductId}, {this.ProductName}, {this.Price}";
        }
    }
}
