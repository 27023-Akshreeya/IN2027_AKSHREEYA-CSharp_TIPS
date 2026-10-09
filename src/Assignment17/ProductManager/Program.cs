namespace ProductManager;

internal class Program
{
    private static void Main(string[] args)
    {
        var productManager = new ProductManager();
        productManager.ProductAdded += (sender, e) =>
        {
            Console.WriteLine(e);
        };

        productManager.AddProduct(new Product("Laptop", "1", 500));
        productManager.AddProduct(new Product("Mouse", "2", 10));
    }
}

public class Product
{
    public Product(string name, string id, decimal price)
    {
        this.Name = name;
        this.Id = id;
        this.Price = price;
    }

    public string Name { get; set; }

    public string Id { get; set; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"ID: {this.Id,-8} | Name: {this.Name,-20} | Price: ${this.Price,-10:F2}";
    }
}

public class ProductManager
{
    private List<Product> _products = new List<Product>();

    public event EventHandler<string> ProductAdded;

    public void AddProduct(Product product)
    {
        this._products.Add(product);
        this.ProductAdded?.Invoke(this, $"New product {product.Name} added");
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return this._products;
    }
}