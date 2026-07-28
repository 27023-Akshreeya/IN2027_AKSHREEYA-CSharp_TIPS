namespace Assignments
{
    using InventoryManager.View;

    /// <summary>
    /// The primary entry point class for the execution of the Inventory Manager application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry execution method that initializes the console viewer and handles global exceptions.
        /// </summary>
        /// <param name="args">The command-line arguments array passed to the application execution process.</param>
        public static void Main(string[] args)
        {
            try
            {
                InventoryManagerViewer userConsole = new InventoryManagerViewer();
                userConsole.Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(InventoryManagerResource.ApplicationError + ex.Message);
                Console.WriteLine(InventoryManagerResource.PressKey);
                Console.ReadKey();
            }
        }
    }
}