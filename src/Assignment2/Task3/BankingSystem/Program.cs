using BankingSystem.ConsoleService;

namespace Assignments
{
    /// <summary>
    /// The main entry point class for the banking application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method that starts up the whole system.
        /// </summary>
        /// <param name="args">The arguments passed from the command line.</param>
        public static void Main(string[] args)
        {
            Service service = new Service();
            service.BankingOperation();
        }
    }
}