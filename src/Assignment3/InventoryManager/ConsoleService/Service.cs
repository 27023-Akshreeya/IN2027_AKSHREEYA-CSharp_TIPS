// <copyright file="Service.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.ConsoleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using InventoryManager.Model;
    using InventoryManager.Repository;

    /// <summary>
    /// Provides business logic services for managing the product inventory.
    /// </summary>
    public class Service
    {
        private readonly Repo _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="repo">
        /// Repository instance used to perform product data operations.
        /// </param>
        public Service(Repo repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Checks if a product with the specified ID exists in the inventory.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to check.</param>
        /// <returns>True if the product exists; otherwise, false.</returns>
        public bool DoesProductExist(string productId)
        {
            var products = this._repo.GetAllProducts();
            return products.Any(x => x.ProductId.Equals(productId));
        }

        /// <summary>
        /// Adds a new product to the inventory.
        /// </summary>
        /// <param name="newProductDetails">An object containing the product name, ID, price, and quantity.</param>
        /// <returns>True if the product was successfully added; otherwise, false.</returns>
        public bool AddNewProduct(Product newProductDetails)
        {
            if (newProductDetails is null)
            {
                return false;
            }

            this._repo.AddProduct(newProductDetails);
            return true;
        }

        /// <summary>
        /// Deletes a product from the inventory based on its unique identifier.
        /// </summary>
        /// <param name="deleteproductId">The unique identifier of the product to delete.</param>
        /// <returns>True if the product was successfully deleted; otherwise, false.</returns>
        public bool RemoveProduct(string deleteproductId)
        {
            var products = this._repo.GetAllProducts();
            var findProductId = products.FirstOrDefault(x => x.ProductId.Equals(deleteproductId));
            if (findProductId != null)
            {
                this._repo.DeleteProduct(findProductId.ProductId);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Searches for a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to search for.</param>
        /// <returns>The found product instance, or null if no product matches the criteria.</returns>
        public Product? SearchByProductId(string productId)
        {
            var products = this._repo.GetAllProducts();
            return products.FirstOrDefault(x => x.ProductId.Equals(productId));
        }

        /// <summary>
        /// Finds a product by its unique identifier and applies a specific update action to it.
        /// </summary>
        /// <param name="productId">The unique identifier of the product to be updated.</param>
        /// <param name="updateAction">The action or logic used to modify the specific product details.</param>
        /// <returns>True if the product was found and successfully updated; otherwise, false.</returns>
        public bool UpdateProductDetails(string productId, Action<Product> updateAction)
        {
            var productToUpdate = this.SearchByProductId(productId);
            if (productToUpdate is null)
            {
                return false;
            }

            updateAction(productToUpdate);
            this._repo.UpdateProduct(productToUpdate, productId);
            return true;
        }

        /// <summary>
        /// Updates the stock quantity of a specific product.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="newProductQuantity">The new stock level or amount for the product.</param>
        /// <returns>True if the quantity was successfully updated; otherwise, false.</returns>
        public bool UpdateProductQuantity(string productId, int newProductQuantity)
        {
            return this.UpdateProductDetails(productId, product => product.Quantity = newProductQuantity);
        }

        /// <summary>
        /// Updates the selling price of a specific product.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="newProductPrice">The new price value to assign to the product.</param>
        /// <returns>True if the price was successfully updated; otherwise, false.</returns>
        public bool UpdateProductPrice(string productId, decimal newProductPrice)
        {
            return this.UpdateProductDetails(productId, product => product.Price = newProductPrice);
        }

        /// <summary>
        /// Updates the display name of a specific product.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="newProductName">The new text name for the product.</param>
        /// <returns>True if the name was successfully updated; otherwise, false.</returns>
        public bool UpdateProductName(string productId, string newProductName)
        {
            return this.UpdateProductDetails(productId, product => product.ProductName = newProductName);
        }

        /// <summary>
        /// Updates the unique identifier (ID) of an existing product.
        /// </summary>
        /// <param name="productId">The current unique identifier of the product.</param>
        /// <param name="newProductId">The new unique identifier to assign to the product.</param>
        /// <returns>True if the product ID was successfully updated; otherwise, false.</returns>
        public bool UpdateProductId(string productId, string newProductId)
        {
            return this.UpdateProductDetails(productId, product => product.ProductId = newProductId);
        }

        /// <summary>
        /// Retrieves all inventory products sorted alphabetically by their name.
        /// </summary>
        /// <returns>A list of sorted product items.</returns>
        public List<Product> ViewAllProducts()
        {
            var products = this._repo.GetAllProducts();
            return products.OrderBy(p => p.ProductName).ToList();
        }

        /// <summary>
        /// checks if the products is empty or not.
        /// </summary>
        /// <returns>true if no products exisits, false otherwise.</returns>
        public bool HasProducts()
        {
            return this._repo.GetAllProducts().Any();
        }
    }
}
