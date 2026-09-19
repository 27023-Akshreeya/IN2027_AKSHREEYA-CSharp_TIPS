using LoggingSystem;

namespace Assignments
{
    /// <summary>
    /// Entry point for testing concurrent user error logging.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Simulates multiple users logging errors simultaneously.
        /// </summary>
        private static void Main()
        {
            List<Task> tasks = new List<Task>();

            for (int user = 1; user <= 5; user++)
            {
                tasks.Add(Task.Run(() => Logger.LogError("User" + user, "Error occurred")));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All users logged successfully.");
        }
    }
}