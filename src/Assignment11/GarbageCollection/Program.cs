using GarbageCollection.Domain;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to START loop");
            Console.ReadLine();
            int loopCount = 10_000_000;
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