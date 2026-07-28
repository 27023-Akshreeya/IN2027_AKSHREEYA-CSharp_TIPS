namespace InventoryManager.ConsoleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using InventoryManager.Model;
    using InventoryManager.Repository;
    using InventoryManager.View;

    /// <summary>
    /// Provides business logic services for managing the product inventory.
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// The repository instance used for data access operations.
        /// </summary>
        private Repo repo = new Repo();

        /// <summary>
        /// Checks if a product with the specified ID exists in the inventory.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to check.</param>
        /// <returns>True if the product exists; otherwise, false.</returns>
        public bool DoesProductExisits(string productId)
        {
            var products = this.repo.GetAllProducts();
            if (products.FirstOrDefault(x => x.ProductId == productId) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a new product to the inventory repo using the provided details tuple.
        /// </summary>
        /// <param name="newProductDetails">A tuple containing the product name, ID, price, and quantity.</param>
        /// <returns>True if the product was successfully added; otherwise, false.</returns>
        internal bool AddNewProduct((string productName, string productID, decimal price, int quantity) newProductDetails)
        {
            Product newproduct = new Product(
                newProductDetails.productName,
                newProductDetails.productID,
                newProductDetails.price,
                newProductDetails.quantity);

            return this.repo.AddProduct(newproduct);
        }

        /// <summary>
        /// Deletes a product from the inventory based on its unique identifier.
        /// </summary>
        /// <param name="deleteproductId">The unique identifier of the product to delete.</param>
        /// <returns>True if the product was successfully deleted; otherwise, false.</returns>
        internal bool DeleteProductById(string deleteproductId)
        {
            var products = this.repo.GetAllProducts();
            var findProductId = products.Find(x => x.ProductId == deleteproductId);
            if (findProductId != null)
            {
                return this.repo.DeleteProduct(findProductId.ProductId);
            }

            return false;
        }

        /// <summary>
        /// Searches for a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to search for.</param>
        /// <returns>The found product instance, or null if no product matches the criteria.</returns>
        internal Product? SearchByProductId(string productId)
        {
            var products = this.repo.GetAllProducts();
            var searchproduct = products.Find(x => x.ProductId == productId);
            return searchproduct;
        }

        /// <summary>
        /// Updates a specific field of an existing product determined by an edit selection choice.
        /// </summary>
        /// <param name="newProductElement">The new string value to apply to the chosen product property.</param>
        /// <param name="productId">The current unique identifier of the product to update.</param>
        /// <param name="editChoice">The selection indicator: 1 for Name, 2 for ID, 3 for Price, any other number for Quantity.</param>
        /// <returns>True if the product update operation succeeds; otherwise, false.</returns>
        internal bool UpdateProductByProductID(string newProductElement, string productId, int editChoice)
        {
            var productToUpdate = this.SearchByProductId(productId);
            if (productToUpdate is null)
            {
                Console.WriteLine(InventoryManagerResource.InvalidInput);
                return false;
            }

            if (editChoice == 1)
            {
                productToUpdate.ProductName = newProductElement;
            }
            else if (editChoice == 2)
            {
                productToUpdate.ProductId = newProductElement;
            }
            else if (editChoice == 3)
            {
                try
                {
                    productToUpdate.Price = decimal.Parse(newProductElement);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(InventoryManagerResource.InvalidInput + ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(InventoryManagerResource.InvalidInput + ex.Message);
                }
            }
            else
            {
                try
                {
                    productToUpdate.Quantity = int.Parse(newProductElement);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(InventoryManagerResource.InvalidInput + ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(InventoryManagerResource.InvalidInput + ex.Message);
                }
            }

            return this.repo.UpdateProduct(productToUpdate, productId);
        }

        /// <summary>
        /// Retrieves all inventory products sorted alphabetically by their name.
        /// </summary>
        /// <returns>A list of sorted product items.</returns>
        internal List<Product> ViewAllProducts()
        {
            var products = this.repo.GetAllProducts();
            List<Product> sortedProducts = products.OrderBy(p => p.ProductName).ToList();
            return sortedProducts;
        }
    }
}
