namespace InventoryManager.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="productID"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public Product(string productName, string productID, decimal price, int quantity)
        {
            this.ProductName = productName;
            this.ProductId = productID;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
    }
}
