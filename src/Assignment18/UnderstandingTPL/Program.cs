using System.Diagnostics;

namespace Assignments
{
    internal class Program
    {
        private const int ArraySize = 500000000;

        private static void Main(string[] args)
        {
            DisplayMessage("Creating a large array", ConsoleColor.Cyan);
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] arrayForParallelOperation = CreateArray();
            stopwatch.Stop();
            int[] arrayForSequentialOperation = CreateArray();
            DisplayMessage($"Time taken to create the array by ParallelFor : {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.Green);
            DisplayMessage($"\nTime taken to square array elements using Parallel.ForEach: {SquareArrayParallely(arrayForParallelOperation)} ms", ConsoleColor.Green);
            DisplayMessage($"\nTime taken to square array elements using sequential For loop: {SquareArraySequentially(arrayForSequentialOperation)} ms", ConsoleColor.Green);
        }

        private static int[] CreateArray()
        {
            int[] array = new int[ArraySize];
            Parallel.For(0, ArraySize, i =>
            {
                array[i] = i + 1;
            });
            return array;
        }

        private static long SquareArraySequentially(int[] largeArray)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < largeArray.Length; i++)
            {
                largeArray[i] = largeArray[i] * largeArray[i];
            }

            stopwatch.Stop();
            DisplayArray(largeArray);
            return stopwatch.ElapsedMilliseconds;
        }

        private static long SquareArrayParallely(int[] largeArray)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(largeArray, (value, state, index) =>
            {
                largeArray[index] = value * value;
            });
            stopwatch.Stop();
            DisplayArray(largeArray);
            return stopwatch.ElapsedMilliseconds;
        }

        private static void DisplayArray(int[] largeArray)
        {
            DisplayMessage("Displaying first 50 array elements after squaring:", ConsoleColor.White);
            for (int i = 0; i < 50; i++)
            {
                Console.Write($"{largeArray[i]} ");
            }
        }

        private static void DisplayMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}