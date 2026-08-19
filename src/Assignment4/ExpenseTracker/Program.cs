using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point for the expense tracking application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Initializes and runs the Expense Tracker application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var repo = new ExpenseTrackerMemoryRepository();
                var service = new ExpenseTrackerService(repo);
                var view = new ExpenseTrackerViewer(service);
                view.DisplayMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}