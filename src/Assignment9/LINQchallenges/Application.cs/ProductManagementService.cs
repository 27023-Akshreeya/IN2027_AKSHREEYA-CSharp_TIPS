using System;
using System.Collections.Generic;
using System.Linq;
using LINQchallenges.Domain;
using LINQchallenges.Infrastucture;

namespace LINQchallenges.Application
{
    internal class ProductManagementService
    {
        private readonly ProductManagementRepository _repository;

        public ProductManagementService(ProductManagementRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this._repository.GetProducts();
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return this._repository.GetSuppliers();
        }

        public bool DoesCategoryExist(string categoryName)
        {
            return this.GetAllProducts().Any(c => c.Category.Equals(categoryName));
        }

        public IEnumerable<object> FilterbyCategoryAndPrice(string categoryName, decimal price)
        {
            return this.GetAllProducts().Where(p => p.Category.Equals(categoryName) && p.Price > price)
                .Select(p => new { p.ProductName,  p.Price }).ToList();
        }

        public IEnumerable<Product> OrderCategoryByDescending(string categoryName, decimal price)
        {
            return this.GetAllProducts()
                .Where(p => p.Category == categoryName && p.Price > price)
                .OrderByDescending(p => p.Price);
        }

        public decimal GetAverage(string categoryName, decimal price)
        {
            return this.GetAllProducts()
                .Where(p => p.Category == categoryName && p.Price > price)
                .Average(p => p.Price);
        }

        public IEnumerable<object> GroupAndCountCategory()
        {
            return this.GetAllProducts()
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count(), MostExpensive = g.MaxBy(p => p.Price) });
        }

        public IEnumerable<object> JoinProductBySupplier()
        {
            return this.GetAllProducts().Join(this.GetAllSuppliers(), p => p.ProductId, s => s.ProductId, (p, s) => new { p.ProductName, Supplier = s.SupplierName });
        }

        public IEnumerable<Product> FilterMaxByProduct()
        {
            return this.GetAllProducts()
                .Where(p => p.Category.Equals("Books"))
                .OrderByDescending(p => p.Price);
        }

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
