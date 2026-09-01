using System;
using System.Linq;
using LINQchallenges.Application;

namespace LINQchallenges.Presentation
{
    /// <summary>
    /// Handles the console user interface and console-based output representation.
    /// </summary>
    internal class ConsoleUI
    {
        private readonly ProductManagementService _productManagementService;
        private readonly ArrayManipulationService _arrayManipulationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
        /// Initializes a <see langword="new"/> instance of the console UI with required application services.
        /// </summary>
        /// <param name="productManagementService">The product management service layer.</param>
        /// <param name="arrayManipulationService">The array manipulation service layer.</param>
        public ConsoleUI(ProductManagementService productManagementService, ArrayManipulationService arrayManipulationService)
        {
            this._productManagementService = productManagementService;
            this._arrayManipulationService = arrayManipulationService;
        }

        /// <summary>
        /// Executes a series of tasks sequentially.
        /// </summary>
        public void Run()
        {
            this.Task1();
            this.Task2();
            this.Task3();
            this.Task4();
            this.Task5();
        }

        /// <summary>
        /// Executes and displays Task 5, demonstrating the custom query builder pattern.
        /// </summary>
        private void Task5()
        {
            var result = this._productManagementService.ExecuteProductQuery();
            Console.WriteLine("\nTask 5 - Query Builder");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to exit");
        }

        /// <summary>
        /// Executes and displays Task 4, sorting and printing all books by price.
        /// </summary>
        private void Task4()
        {
            Console.WriteLine("\ntask 4 - Sort all books by price");
            foreach (var product in this._productManagementService.FilterMaxByProduct())
            {
                Console.WriteLine($"Product Id: {product.ProductId}, Product name: {product.ProductName}, Price : {product.Price}");
            }
        }

        /// <summary>
        /// Prompts the user for a numeric string and converts it safely to an integer.
        /// </summary>
        /// <param name="userPrompt">The text message to display to the user.</param>
        /// <returns>The parsed integer, or 0 if validation fails.</returns>
        private int GetNumericInput(string userPrompt)
        {
            Console.Write(userPrompt);
            string userInput = Console.ReadLine() ?? string.Empty;
            if (!InputValidator.IsNumberValid(userInput))
            {
                Console.WriteLine("Invalid input!");
                return 0;
            }

            return Convert.ToInt32(userInput);
        }

        /// <summary>
        /// Executes Task 3, managing user inputs to test array processing and target sum matching via LINQ.
        /// </summary>
        private void Task3()
        {
            Console.Write("\nTask 3 - array manipulation using LINQ\n");
            int arraySize = this.GetNumericInput("Enter Array size:");
            if (arraySize <= 0)
            {
                return;
            }

            var array = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                int arrayElement = this.GetNumericInput($"Enter element {i + 1}:");
                if (arrayElement == 0)
                {
                    return;
                }

                array[i] = arrayElement;
            }

            Console.WriteLine($"The second highest of the array is : {this._arrayManipulationService.GetSecondHighestArrayElement(array)}");
            Console.Write("\nEnter target sum: ");
            var target = Console.ReadLine() ?? string.Empty;
            if (!InputValidator.IsNumberValid(target))
            {
                Console.WriteLine("invalid target");
                return;
            }

            foreach (var pair in this._arrayManipulationService.GetSumPairs(array, int.Parse(target)))
            {
                Console.WriteLine(pair);
            }
        }

        /// <summary>
        /// Executes and displays Task 2, aggregating product metrics and counts by category.
        /// </summary>
        private void Task2()
        {
            Console.Write("\nTask 2 - The count and most expensive product in each category:\n");
            foreach (dynamic product in this._productManagementService.GroupAndCountCategory())
            {
                Console.WriteLine($"Category: {product.Category}, count: {product.Count}, Most expensive: {product.MostExpensive}");
            }
        }

        /// <summary>
        /// Captures and validates a category name entered by the user.
        /// </summary>
        /// <returns>A validated category name, or an empty string if invalid.</returns>
        private string GetProductCategory()
        {
            Console.WriteLine("Available categories:\nElectronics, Books, Accessories, Furniture\n");
            Console.Write("Enter product Category:");
            string productCategory = Console.ReadLine() ?? string.Empty;
            if (productCategory.Equals(string.Empty) || !this._productManagementService.DoesCategoryExist(productCategory))
            {
                Console.WriteLine("invaild input!");
                return string.Empty;
            }

            return productCategory;
        }

        /// <summary>
        /// Captures and validates a decimal product price entered by the user.
        /// </summary>
        /// <returns>The validated decimal value, or -1 if invalid.</returns>
        private decimal GetPrice()
        {
            Console.Write("Enter product price:");
            string price = Console.ReadLine() ?? string.Empty;
            if (!InputValidator.IsPriceValid(price))
            {
                Console.WriteLine("invaild input!");
                return -1;
            }

            return decimal.Parse(price);
        }

        /// <summary>
        /// Executes Task 1, requesting criteria to filter, sort, and average products.
        /// </summary>
        private void Task1()
        {
            Console.WriteLine("task 1 - Filter products under the category and price:\n");
            string category = this.GetProductCategory();
            if (category.Equals(string.Empty))
            {
                return;
            }

            decimal price = this.GetPrice();
            if (price.Equals(-1))
            {
                return;
            }

            Console.WriteLine("Filtered product by category and price");
            var products = this._productManagementService.FilterbyCategoryAndPrice(category, price).ToList();
            if (products.Count <= 0)
            {
                Console.WriteLine("Product does not exists under these condition");
                return;
            }

            foreach (dynamic product in products)
            {
                Console.WriteLine($"Product Name: {product.ProductName}, Price: {product.Price}");
            }

            Console.WriteLine("\nSorted Products:");
            var items = this._productManagementService.OrderCategoryByDescending(category, price);
            if (items is null)
            {
                Console.WriteLine("Product does not exists under these condition");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine($"{item.ProductName} {item.Price}");
            }

            Console.WriteLine($"\nAverage of Products: {this._productManagementService.GetAverage(category, price)}");
        }
    }
}
