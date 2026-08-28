using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQchallenges.Application;
using LINQchallenges.Domain;

namespace LINQchallenges.Presentation
{
    internal class ConsoleUI
    {
        private readonly ProductManagementService _productManagementService;
        private readonly ArrayManipulationService _arrayManipulationService;

        public ConsoleUI(ProductManagementService productManagementService, ArrayManipulationService arrayManipulationService)
        {
            this._productManagementService = productManagementService;
            this._arrayManipulationService = arrayManipulationService;
        }

        public void Run()
        {
            this.Task1();
            this.Task2();
            this.Task3();
            this.Task4();
            this.Task5();
        }

        public void Task5()
        {
            var result = this._productManagementService.ExecuteProductQuery();

            Console.WriteLine("\nTask 5 - Query Builder");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to exit");
        }

        public void Task4()
        {
            Console.WriteLine("\ntask 4 - Sort all books by price");
            foreach (var product in this._productManagementService.FilterMaxByProduct())
            {
                Console.WriteLine($"Product Id: {product.ProductId}, Product name: {product.ProductName}, Price : {product.Price}");
            }
        }

        public int GetNumericInput(string userPrompt)
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

        public void Task3()
        {
            Console.Write("\nTask 5 - array manipulation using LINQ\n");

            int arraySize = this.GetNumericInput("Enter Array size:");
            if (arraySize <= 0)
            {
                return;
            }

            int[] array = new int[arraySize];
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

        public void Task2()
        {
            Console.Write("\nTask 2 - The count and most expensive product in each category:\n");
            foreach (dynamic product in this._productManagementService.GroupAndCountCategory())
            {
                Console.WriteLine($"Category: {product.Category}, count: {product.Count}, Most expensive: {product.MostExpensive}");
            }
        }

        public string GetProductCategory()
        {
            Console.Write("Enter product Category:");
            string productCategory = Console.ReadLine() ?? string.Empty;
            if (productCategory.Equals(string.Empty) || !this._productManagementService.DoesCategoryExist(productCategory))
            {
                Console.WriteLine("invaild input!");
                return string.Empty;
            }

            return productCategory;
        }

        public decimal GetPrice()
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

        public void Task1()
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
