namespace InventoryManager.Model
{
    /// <summary>
    /// Represents a product entity in the inventory system with its stock and pricing details.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified details.
        /// </summary>
        /// <param name="productName">The name or description of the product.</param>
        /// <param name="productID">The unique identifier alphanumeric string for the product.</param>
        /// <param name="price">The unit price cost of the product.</param>
        /// <param name="quantity">The total stock count available for the product.</param>
        public Product(string productName, string productID, decimal price, int quantity)
        {
            this.ProductName = productName;
            this.ProductId = productID;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the unique alphanumeric identifier for the product.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the display name or title of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the current stock quantity available in the inventory.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the monetary unit price of the product.
        /// </summary>
        public decimal Price { get; set; }
    }
}
