using MemoryOptimization;

namespace Assignments
{
    /// <summary>
    /// Contains the main execution logic for the memory optimization assignment.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Serves as the entry point for the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        public static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
        }
    }
}
