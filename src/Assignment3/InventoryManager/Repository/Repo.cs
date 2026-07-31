// <copyright file="Repo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.Repository
{
    using InventoryManager.Model;

    /// <summary>
    /// Manages the in-memory data store and CRUD operations for the product inventory.
    /// </summary>
    internal class Repo
    {
        /// <summary>
        /// The internal list storing all active products in the inventory system.
        /// </summary>
        private List<Product> products = new List<Product>();

        /// <summary>
        /// Retrieves the entire collection of products stored in the repository.
        /// </summary>
        /// <returns>A list containing all current <see cref="Product"/> instances.</returns>
        internal List<Product> GetAllProducts() => this.products;

        /// <summary>
        /// Appends a new product to the inventory data store collection.
        /// </summary>
        /// <param name="newproduct">The instance of the product data model to add.</param>
        /// <returns>True if the product item was successfully added; otherwise, false.</returns>
        internal bool AddProduct(Product newproduct)
        {
            this.products.Add(newproduct);
            return true;
        }

        /// <summary>
        /// Removes a specific product from the data collection using its unique tracking identifier.
        /// </summary>
        /// <param name="productId">The unique identifier alphanumeric string for the product to delete.</param>
        /// <returns>True if the deletion operation finishes successfully; otherwise, false.</returns>
        internal bool DeleteProduct(string productId)
        {
            var deleteContact = this.products.Find(x => x.ProductId == productId);
            if (deleteContact != null)
            {
                this.products.Remove(deleteContact);
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
            var findProductId = this.products.Find(p => p.ProductId == productId);
            if (findProductId != null)
            {
                findProductId.ProductId = productToUpdate.ProductId;
                findProductId.ProductName = productToUpdate.ProductName;
                findProductId.Price = productToUpdate.Price;
                findProductId.Quantity = productToUpdate.Quantity;
            }

            return true;
        }
    }
}
