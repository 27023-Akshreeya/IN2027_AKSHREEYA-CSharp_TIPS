using GarbageCollection.Domain;

namespace Assignments
{
    /// <summary>
    /// Application entry point demonstrating garbage collection behavior.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Executes the loop memory allocation and triggers manual garbage collection.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to START loop");
            Console.ReadLine();
            int loopCount = 10000000;
            for (int i = 0; i < loopCount; i++)
            {
                new Structure { X = i };
            }

            Console.WriteLine("Loop finished. ");
            Console.WriteLine("Triggering GC.Collect()");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("GC Complete.");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
