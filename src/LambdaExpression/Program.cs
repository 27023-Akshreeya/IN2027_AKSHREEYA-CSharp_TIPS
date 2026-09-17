namespace Assignments
{
    /// <summary>
    /// Demonstrates the use of lambda expressions in C#.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the console application demonstrating lambda expressions.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        private static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 5, 2, 9, 1, 5, 6, 10, 3, 8, 12 };
            Console.WriteLine($"Original list: {string.Join(", ", numbers)}");
            var oddNumbers = FilterOddNumbers(numbers);
            SquareNumbers(oddNumbers);
            Console.WriteLine("Additional LINQ operations");
            SortUniqueNumbers(numbers);
            Console.WriteLine($"Product of numbers: {ProductOfNumbers(numbers)}");
        }

        /// <summary>
        /// Filters the odd numbers from the provided list using a lambda expression.
        /// </summary>
        /// <param name="numbers">The list of numbers to filter.</param>
        /// <returns>A list containing only the odd numbers.</returns>
        private static List<int> FilterOddNumbers(List<int> numbers)
        {
            var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
            Console.WriteLine($"Filtered Odd numbers: {string.Join(", ", oddNumbers)}");
            return oddNumbers;
        }

        /// <summary>
        /// Squares the numbers in the provided list using a lambda expression and prints the result.
        /// </summary>
        /// <param name="numbers">The list of numbers to square.</param>
        private static void SquareNumbers(List<int> numbers)
        {
            var squaredNumbers = numbers.Select(n => n * n).ToList();
            Console.WriteLine($"Squared List of odd numbers: {string.Join(", ", squaredNumbers)}");
        }

        /// <summary>
        /// Sorts the unique numbers from the provided list using LINQ and prints the result.
        /// </summary>
        /// <param name="numbers">The list of numbers to sort.</param>
        private static void SortUniqueNumbers(List<int> numbers)
        {
            var sortedNumbers = numbers.Distinct().OrderBy(n => n).ToList();
            Console.WriteLine($"Sorted numbers: {string.Join(", ", sortedNumbers)}");
        }

        /// <summary>
        /// Calculates the product of the numbers in the provided list using a lambda expression and prints the result.
        /// </summary>
        /// <param name="numbers">The list of numbers to calculate the product for.</param>
        /// <returns>The product of the numbers.</returns>
        private static int ProductOfNumbers(List<int> numbers)
        {
            var product = numbers.Aggregate(1, (current, next) => current * next);
            Console.WriteLine($"Product of numbers: {product}");
            return product;
        }
    }
}