using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var repo = new Repo();
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