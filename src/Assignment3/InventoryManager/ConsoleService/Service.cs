// <copyright file="Service.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.ConsoleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using InventoryManager.Model;
    using InventoryManager.Model.Enums;
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
        /// Updates a specific field of an existing product determined by an edit selection choice.
        /// </summary>
        /// <param name="newProductElement">The new string value to apply to the chosen product property.</param>
        /// <param name="productId">The current unique identifier of the product to update.</param>
        /// <param name="editChoice">The selection indicator: 1 for Name, 2 for ID, 3 for Price, any other number for Quantity.</param>
        /// <returns>True if the product update operation succeeds; otherwise, false.</returns>
        public bool UpdateProductDetails(string newProductElement, string productId, EditChoices editChoice)
        {
            var productToUpdate = this.SearchByProductId(productId);
            if (productToUpdate is null)
            {
                return false;
            }

            switch (editChoice)
            {
                case EditChoices.ProductName:
                    productToUpdate.ProductName = newProductElement;
                    break;
                case EditChoices.ProductId:
                    productToUpdate.ProductId = newProductElement;
                    break;
                case EditChoices.Price:
                    productToUpdate.Price = decimal.Parse(newProductElement);

                    break;
                case EditChoices.Quantity:
                    productToUpdate.Quantity = int.Parse(newProductElement);

                    break;
                default:
                    return false;
            }

            this._repo.UpdateProduct(productToUpdate, productId);
            return true;
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
