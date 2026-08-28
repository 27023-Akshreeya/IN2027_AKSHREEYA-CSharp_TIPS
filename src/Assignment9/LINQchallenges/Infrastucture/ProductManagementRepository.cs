using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQchallenges.Domain;

namespace LINQchallenges.Infrastucture
{
    /// <summary>
    /// Mock repository providing sample in-memory product and supplier data.
    /// </summary>
    public class ProductManagementRepository
    {
        private readonly List<Product> _products = new ()
{
    new Product { ProductId = 1, ProductName = "Laptop", Price = 900, Category = "Electronics" },
    new Product { ProductId = 2, ProductName = "Phone", Price = 700, Category = "Electronics" },
    new Product { ProductId = 3, ProductName = "Headphones", Price = 150, Category = "Electronics" },
    new Product { ProductId = 4, ProductName = "C# Book", Price = 60, Category = "Books" },
    new Product { ProductId = 5, ProductName = "Keyboard", Price = 120, Category = "Accessories" },
    new Product { ProductId = 6, ProductName = "Monitor", Price = 400, Category = "Electronics" },
    new Product { ProductId = 7, ProductName = "Novel", Price = 25, Category = "Books" },
    new Product { ProductId = 8, ProductName = "Mouse", Price = 80, Category = "Accessories" },
    new Product { ProductId = 9, ProductName = "Clean Code", Price = 70, Category = "Books" },
    new Product { ProductId = 10, ProductName = "Gaming Chair", Price = 350, Category = "Furniture" },
    new Product { ProductId = 11, ProductName = "Desk", Price = 250, Category = "Furniture" },
    new Product { ProductId = 12, ProductName = "Tablet", Price = 500, Category = "Electronics" },
    new Product { ProductId = 13, ProductName = "Power Bank", Price = 100, Category = "Accessories" },
    new Product { ProductId = 14, ProductName = "Design Patterns", Price = 90, Category = "Books" },
    new Product { ProductId = 15, ProductName = "Webcam", Price = 180, Category = "Electronics" },
};

        private readonly List<Supplier> _suppliers = new ()
{
    new Supplier { SupplierId = 1, SupplierName = "Dell", ProductId = 1 },
    new Supplier { SupplierId = 2, SupplierName = "Samsung", ProductId = 2 },
    new Supplier { SupplierId = 3, SupplierName = "Sony", ProductId = 3 },
    new Supplier { SupplierId = 4, SupplierName = "Packt", ProductId = 4 },
    new Supplier { SupplierId = 5, SupplierName = "Logitech", ProductId = 5 },
    new Supplier { SupplierId = 6, SupplierName = "LG", ProductId = 6 },
    new Supplier { SupplierId = 7, SupplierName = "Penguin", ProductId = 7 },
    new Supplier { SupplierId = 8, SupplierName = "Logitech", ProductId = 8 },
    new Supplier { SupplierId = 9, SupplierName = "Prentice Hall", ProductId = 9 },
    new Supplier { SupplierId = 10, SupplierName = "IKEA", ProductId = 10 },
    new Supplier { SupplierId = 11, SupplierName = "IKEA", ProductId = 11 },
    new Supplier { SupplierId = 12, SupplierName = "Apple", ProductId = 12 },
    new Supplier { SupplierId = 13, SupplierName = "Anker", ProductId = 13 },
    new Supplier { SupplierId = 14, SupplierName = "O'Reilly", ProductId = 14 },
    new Supplier { SupplierId = 15, SupplierName = "Logitech", ProductId = 15 },
};

        /// <summary>
        /// Retrieves the complete list of mock suppliers.
        /// </summary>
        /// <returns>A collection of suppliers.</returns>
        public IEnumerable<Supplier> GetSuppliers()
        {
            return this._suppliers;
        }

        /// <summary>
        /// Retrieves the complete list of mock products.
        /// </summary>
        /// <returns>A collection of products.</returns>
        public IEnumerable<Product> GetProducts()
        {
            return this._products;
        }
    }
}
