// <copyright file="Repo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.Repository
{
    using InventoryManager.Model;

    /// <summary>
    /// Manages the in-memory data store and CRUD operations for the product inventory.
    /// </summary>
    public class Repo
    {
        /// <summary>
        /// The intrenal list storing all active products in the inventory system.
        /// </summary>
        private List<Product> _products = new List<Product>();

        /// <summary>
        /// Retrieves the entire collection of products stored in the repository.
        /// </summary>
        /// <returns>A list containing all current <see cref="Product"/> instances.</returns>
        public IReadOnlyList<Product> GetAllProducts() => this._products.AsReadOnly();

        /// <summary>
        /// Appends a new product to the inventory data store collection.
        /// </summary>
        /// <param name="newProduct">The instance of the product data model to add.</param>
        public void AddProduct(Product newProduct)
        {
            this._products.Add(newProduct);
        }

        /// <summary>
        /// Removes a specific product from the data collection using its unique tracking identifier.
        /// </summary>
        /// <param name="productId">The unique identifier alphanumeric string for the product to delete.</param>
        public void DeleteProduct(string productId)
        {
            this._products.RemoveAll(x => x.ProductId.Equals(productId));
        }

        /// <summary>
        /// Updates the properties of an existing product identified by the specified product ID.
        /// </summary>
        /// <param name="productToUpdate">The product containing updated values.</param>
        /// <param name="productId">The unique identifier of the product to update.</param>
        public void UpdateProduct(Product productToUpdate, string productId)
        {
            var existingProduct = this._products.Find(p => p.ProductId.Equals(productId));
            if (existingProduct != null)
            {
                existingProduct.ProductId = productToUpdate.ProductId;
                existingProduct.ProductName = productToUpdate.ProductName;
                existingProduct.Price = productToUpdate.Price;
                existingProduct.Quantity = productToUpdate.Quantity;
            }
        }
    }
}
