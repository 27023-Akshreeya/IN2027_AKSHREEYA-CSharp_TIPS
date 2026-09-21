namespace AnonymousMethods
{
    /// <summary>
    /// Demonstrates the use of anonymous methods in C# for sorting.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the console application demonstrating anonymous methods.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Using anonymous method to sort an integer array:");
            int[] array = { 42, 7, 89, 14, 56, 33, 91, 2, 78, 65 };
            DisplayArray(array, "Array before sorting");
            CustomArraySort(array);
            DisplayArray(array, "Array after sorting");

            Console.WriteLine("Using anonymous method to sort a list of strings:");
            var list = new List<string> { "apple", "date", "cherry", "elderberry", "banana" };
            DisplayList(list, "List before sorting");
            CustomListSort(list);
            DisplayList(list, "List after sorting");

            Console.WriteLine("Using anonymous method to sort a string array:");
            string[] array2 = { "Volvo", "BMW", "Ford", "Mazda" };
            DisplayArray(array2, "Array before sorting");
            CustomArraySort(array2);
            DisplayArray(array2, "Array after sorting");
        }

        /// <summary>
        /// Sorts an array of type T using an anonymous method for comparison.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to sort.</param>
        private static void CustomArraySort<T>(T[] array)
            where T : IComparable<T>
        {
            Array.Sort(array, delegate(T item1, T item2)
            {
                return item1.CompareTo(item2);
            });
        }

        /// <summary>
        /// Sorts a list of type T using an anonymous method for comparison.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to sort.</param>
        private static void CustomListSort<T>(List<T> list)
            where T : IComparable<T>
        {
            list.Sort(delegate(T item1, T item2)
            {
                return item1.CompareTo(item2);
            });
        }

        /// <summary>
        /// Displays the contents of an array with a message.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to display.</param>
        /// <param name="message">The message to display.</param>
        private static void DisplayArray<T>(T[] array, string message)
        {
            Console.WriteLine($"{message} : {string.Join(", ", array)}\n");
        }

        /// <summary>
        /// Displays the contents of a list with a message.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to display.</param>
        /// <param name="message">The message to display.</param>
        private static void DisplayList<T>(List<T> list, string message)
        {
            Console.WriteLine($"{message} : {string.Join(", ", list)}\n");
        }
    }
}