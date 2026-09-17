namespace DelegatesForSorting
{
    /// <summary>
    /// Represents a product with a name, category, and price.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified properties.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="category">The category the product belongs to.</param>
        /// <param name="price">The retail price of the product.</param>
        public Product(string name, string category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        /// <value>The category of the product.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>The price of the product.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Returns a formatted string representation of the product properties.
        /// </summary>
        /// <returns>A string containing the product's name, category, and price formatted for alignment.</returns>
        public override string ToString()
        {
            return $"Name : {this.Name,-12} | Category : {this.Category,-15} | Price: ${this.Price:F2}";
        }
    }
}
