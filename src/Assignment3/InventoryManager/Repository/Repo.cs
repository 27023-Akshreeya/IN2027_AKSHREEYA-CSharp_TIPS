using InventoryManager.Model;

namespace InventoryManager.Repository
{
    /// <summary>
    /// 
    /// </summary>
    internal class Repo
    {
        /// <summary>
        /// 
        /// </summary>
        private List<Product> Products = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts() => this.Products;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newproduct"></param>
        /// <returns></returns>
        internal bool AddProduct(Product newproduct)
        {
            this.Products.Add(newproduct);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        internal bool DeleteProduct(string productId)
        {
            var deleteContact = this.Products.Find(x => x.ProductId == productId);
            if (deleteContact != null)
            {
                this.Products.Remove(deleteContact);
            }

            return true;
        }

        /// <summary>
        /// Updates the properties of an existing product identified by the specified product ID.
        /// </summary>
        /// <param name="productToUpdate">The product containing updated values.</param>
        /// <param name="productId">The unique identifier of the product to update.</param>
        /// <returns>true if the product was updated; otherwise, false.</returns>
        internal bool UpdateProduct(Product productToUpdate, string productId)
        {
            var findProductId = this.Products.Find(p => p.ProductId == productId);
            if (findProductId != null)
            {
                findProductId.ProductId = productToUpdate.ProductId;
                findProductId.ProductName = productToUpdate.ProductName;
                findProductId.Price = productToUpdate.Price;
                findProductId.Quantity = productToUpdate.Quantity;
            }

            return true;
        }

        /*internal bool UpdateProduct(Product productToUpdate, string productId)
        {
            if (this.DeleteProduct(productId))
            {
                this.AddProduct(productToUpdate);
            }

            return true;
        }*/
    }
}
