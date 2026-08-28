using System;
using LINQchallenges.Application;
using LINQchallenges.Infrastucture;
using LINQchallenges.Presentation;

namespace Assignments
{
    /// <summary>
    /// The main execution entry point class for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Bootstraps dependencies, initializes services, and starts the Console UI runtime pipeline.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            try
            {
                var productRepo = new ProductManagementRepository();
                var productService = new ProductManagementService(productRepo);
                var arraySerivce = new ArrayManipulationService();
                var viewer = new ConsoleUI(productService, arraySerivce);
                viewer.Run();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
