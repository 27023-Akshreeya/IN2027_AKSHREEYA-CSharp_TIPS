using BankingSystem.Helper;
using BankingSystem.Service;
using BankingSystem.View;

namespace BankingSystem
{
    /// <summary>
    /// Entry point of the banking system application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starts the banking system application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            BankingSystemService service = new BankingSystemService();
            BankingSystemViewer viewer = new BankingSystemViewer(service);

            viewer.BankingOperation();
        }
    }
}