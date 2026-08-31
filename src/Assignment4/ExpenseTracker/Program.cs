using System;
using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    /// <summary>
    /// Entry point for the Expense Tracker application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point that initializes and runs the expense tracker.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var repo = new ExpenseTrackerRepository();
                var service = new ExpenseTrackerService(repo);
                var view = new ExpenseTrackerViewer(service);
                view.DisplayMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}