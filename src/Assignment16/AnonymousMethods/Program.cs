namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Using anonymous method to sort an integer array:");
            int[] array = { 42, 7, 89, 14, 56, 33, 91, 2, 78, 65 };
            Console.WriteLine($"Array before sorting : {string.Join(", ", array)}");
            CustomArraySort(array);
            Console.WriteLine($"Array After sorting {string.Join(", ", array)}\n");
            Console.WriteLine("Using anonymous method to sort a list of strings:");
            List<string> list = new List<string> { "apple", "date", "cherry", "elderberry", "banana" };
            Console.WriteLine($"List before sorting : {string.Join(", ", list)}");
            CustomListSort(list);
            Console.WriteLine($"List After sorting : {string.Join(", ", list)}\n");
            Console.WriteLine("Using anonymous method to sort a string array:");
            string[] array2 = { "Volvo", "BMW", "Ford", "Mazda" };
            Console.WriteLine($"Array before sorting : {string.Join(", ", array2)}");
            CustomArraySort(array2);
            Console.WriteLine($"Array After sorting {string.Join(", ", array2)}");
        }

        private static void CustomArraySort<T>(T[] array)
            where T : IComparable<T>
        {
            Array.Sort(array, delegate(T item1, T item2)
            {
                return item1.CompareTo(item2);
            });
        }

        private static void CustomListSort<T>(List<T> list)
            where T : IComparable<T>
        {
            list.Sort(delegate(T item1, T item2)
            {
                return item1.CompareTo(item2);
            });
        }
    }
}