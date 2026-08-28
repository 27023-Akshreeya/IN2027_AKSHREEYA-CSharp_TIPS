using System;
using LINQchallenges.Application;
using LINQchallenges.Infrastucture;
using LINQchallenges.Presentation;

namespace Assignments
{
    internal class Program
    {
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