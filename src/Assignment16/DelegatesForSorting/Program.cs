using static ProductSortService.Sort;

namespace ProductSortService;

internal class Program
{
    public static List<Product> Products = new List<Product>
{
new Product("Laptop", "Electronics", 899.99m),
new Product("Running Shoes", "Clothing", 79.50m),
new Product("Air Fryer", "Home & Kitchen", 129.95m),
new Product("Sci-Fi Novel", "Books", 14.99m),
new Product("Wireless Headphones", "Electronics", 199.99m),
new Product("Jeans", "Clothing", 45.00m),
new Product("Coffee Maker", "Home & Kitchen", 89.99m),
new Product("Biography", "Books", 24.95m),
new Product("Smartwatch", "Electronics", 249.99m),
new Product("Winter Jacket", "Clothing", 150.00m)
};

    static void Main(string[] args)
    {
        var sorting = new Sort();
        SortAndDisplay(Products, sorting.SortByName, "Sorting by name");
        SortAndDisplay(Products, sorting.SortByCategory, "Sorting by category");
        SortAndDisplay(Products, sorting.SortByPrice, "Sorting by price");
    }

    public static void SortAndDisplay(List<Product> products, SortDelegate sorter, string sortDescription)
    {
        products.Sort((p1, p2) => sorter(p1, p2));
        Console.WriteLine("\n" + sortDescription);
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}