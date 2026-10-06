using System;
using System.Linq;
using System.Threading;

namespace UsageOfMultiThreading
{
    /// <summary>
    /// Demonstrates the usage of multi-threading by performing different operations on an array of integers
    /// </summary>
    internal class Program
    {
        private static int[] array = { 3, 2, 8, 6, 5, 1, 7, 10, 9, 4 };

        private static void Main(string[] args)
        {
            int sumOfEvenNumbers = 0;
            int[] sortedArray = null;
            int[] arraySquare = null;
            Thread thread1 = new Thread(() => sumOfEvenNumbers = SumEvenNumbers());
            thread1.Name = "SumEvenNumbersThread";
            Thread thread2 = new Thread(() => sortedArray = SortArray());
            thread2.Name = "SortArrayThread";
            Thread thread3 = new Thread(() => arraySquare = SqaureArrayElements());
            thread3.Name = "SquareArrayElementsThread";
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            Console.WriteLine($"Sum of even number in the array : {sumOfEvenNumbers}" +
                $"\nSorted array : {string.Join(", ", sortedArray)} " +
                $"\nSquare of array elements : {string.Join(", ", arraySquare)}");
        }

        private static int[] SqaureArrayElements()
        {
            Console.WriteLine($"Square of array elements performed by {Thread.CurrentThread.Name}");
            return array.Select(x => x * x).ToArray();
        }

        private static int[] SortArray()
        {
            Console.WriteLine($"Sorting of array performed by {Thread.CurrentThread.Name}");
            return array.OrderBy(x => x).ToArray();
        }

        private static int SumEvenNumbers()
        {
            Console.WriteLine($"Sum of even numbers performed by {Thread.CurrentThread.Name}");
            return array.Where(x => x % 2 == 0).Sum();
        }
    }
}