using static DelegatesForSorting.Sort;

namespace DelegatesForSorting
{
    /// <summary>
    /// Provides the main entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// A static collection of sample products.
        /// </summary>
        private static List<Product> _products = new List<Product>
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
            new Product("Winter Jacket", "Clothing", 150.00m),
        };

        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        private static void Main(string[] args)
        {
            var sorting = new Sort();
            SortAndDisplay(_products, sorting.SortByName, "Sorting by name");
            SortAndDisplay(_products, sorting.SortByCategory, "Sorting by category");
            SortAndDisplay(_products, sorting.SortByPrice, "Sorting by price");
        }

        /// <summary>
        /// Sorts the specified list of products using the provided delegate and displays the sorted products with a
        /// description of the sorting applied.
        /// </summary>
        /// <param name="products">The list of products to sort and display.</param>
        /// <param name="sorter">The delegate that defines the sorting order for the products.</param>
        /// <param name="sortDescription">A description of the sorting criteria used.</param>
        private static void SortAndDisplay(List<Product> products, SortDelegate sorter, string sortDescription)
        {
            products.Sort((p1, p2) => sorter(p1, p2));
            Console.WriteLine("\n" + sortDescription);
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
