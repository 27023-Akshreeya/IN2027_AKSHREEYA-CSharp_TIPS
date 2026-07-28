namespace InventoryManager.ConsoleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using InventoryManager.Model;
    using InventoryManager.Repository;
    using InventoryManager.View;

    /// <summary>
    /// 
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// 
        /// </summary>
        private Repo repo = new Repo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DoesProductExisits (string productId)
        {
            var products = this.repo.GetAllProducts();
            if (products.FirstOrDefault(x => x.ProductId == productId) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProductDetails"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="deleteproductId"></param>
        /// <returns></returns>
        internal bool DeleteProductById(string deleteproductId)
        {
            var products = this.repo.GetAllProducts();
            var findProductId = products.Find(x => x.ProductId == deleteproductId);
            return this.repo.DeleteProduct(findProductId.ProductId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        internal Product? SearchByProductId(string productId)
        {
            var products = this.repo.GetAllProducts();
            var searchproduct = products.Find(x => x.ProductId == productId);
            return searchproduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProductElement"></param>
        /// <param name="productId"></param>
        /// <param name="editChoice"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        internal List<Product> ViewAllProducts()
        {
            var products = this.repo.GetAllProducts();
            List<Product> sortedProducts = products.OrderBy(p => p.ProductName).ToList();
            return sortedProducts;
        }
    }
}
