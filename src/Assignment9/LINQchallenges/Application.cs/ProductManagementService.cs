using System.Collections.Generic;
using System.Linq;
using LINQchallenges.Domain;
using LINQchallenges.Infrastucture;

namespace LINQchallenges.Application
{
    /// <summary>
    /// Manages and queries product and supplier data.
    /// </summary>
    public class ProductManagementService
    {
        private readonly ProductManagementRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManagementService"/> class.
        /// Initializes a new instance of the service.
        /// </summary>
        /// <param name="repository">The data repository.</param>
        public ProductManagementService(ProductManagementRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Retrieves all products from the repository.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return this._repository.GetProducts();
        }

        /// <summary>
        /// Retrieves all suppliers from the repository.
        /// </summary>
        /// <returns>A collection of all suppliers.</returns>
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return this._repository.GetSuppliers();
        }

        /// <summary>
        /// Checks if a specific product category exists.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <returns>True if the category exists; otherwise, false.</returns>
        public bool DoesCategoryExist(string categoryName)
        {
            return this.GetAllProducts().Any(c => c.Category.Equals(categoryName));
        }

        /// <summary>
        /// Filters products by category and a minimum price threshold.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <param name="price">The minimum price threshold.</param>
        /// <returns>An anonymous collection containing product names and prices.</returns>
        public IEnumerable<object> FilterbyCategoryAndPrice(string categoryName, decimal price)
        {
            return this.GetAllProducts().Where(p => p.Category.Equals(categoryName) && p.Price > price)
                .Select(p => new { p.ProductName, p.Price }).ToList();
        }

        /// <summary>
        /// Retrieves products in a category above a minimum price, ordered descending by price.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <param name="price">The minimum price threshold.</param>
        /// <returns>An ordered collection of products.</returns>
        public IEnumerable<Product> OrderCategoryByDescending(string categoryName, decimal price)
        {
            return this.GetAllProducts()
                .Where(p => p.Category.Equals(categoryName) && p.Price > price)
                .OrderByDescending(p => p.Price);
        }

        /// <summary>
        /// Calculates the average price of products in a category that exceed a minimum price.
        /// </summary>
        /// <param name="categoryName">The name of the category.</param>
        /// <param name="price">The minimum price threshold.</param>
        /// <returns>The average price of the filtered products.</returns>
        public decimal GetAverage(string categoryName, decimal price)
        {
            return this.GetAllProducts()
                .Where(p => p.Category.Equals(categoryName) && p.Price > price)
                .Average(p => p.Price);
        }

        /// <summary>
        /// Groups products by category and calculates counts and maximum prices.
        /// </summary>
        /// <returns>A summary collection containing categories, item counts, and most expensive products.</returns>
        public IEnumerable<object> GroupAndCountCategory()
        {
            return this.GetAllProducts()
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count(), MostExpensive = g.MaxBy(p => p.Price) });
        }

        /// <summary>
        /// Joins products with their corresponding suppliers by ID.
        /// </summary>
        /// <returns>A collection matching product names with supplier names.</returns>
        public IEnumerable<object> JoinProductBySupplier()
        {
            return this.GetAllProducts().Join(this.GetAllSuppliers(), p => p.ProductId, s => s.ProductId, (p, s) => new { p.ProductName, Supplier = s.SupplierName });
        }

        /// <summary>
        /// Retrieves all products in the "Books" category ordered descending by price.
        /// </summary>
        /// <returns>A collection of book products sorted by price.</returns>
        public IEnumerable<Product> FilterMaxByProduct()
        {
            return this.GetAllProducts()
                .Where(p => p.Category.Equals("Books"))
                .OrderByDescending(p => p.Price);
        }

        /// <summary>
        /// Builds and executes a complex query filtering, sorting, and joining products with suppliers.
        /// </summary>
        /// <returns>A detailed collection of matched product and supplier fields.</returns>
        public IEnumerable<object> ExecuteProductQuery()
        {
            return new QueryBuilder<Product>(this.GetAllProducts())
                .Filter(p => p.Price > 100)
                .SortBy(p => p.Price)
                .Join(this.GetAllSuppliers(), p => p.ProductId, s => s.ProductId, (p, s) => new
                {
                    ProductName = p.ProductName,
                    ProductId = p.ProductId,
                    Price = p.Price,
                    Category = p.Category,
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                })
                .Execute();
        }
    }
}
