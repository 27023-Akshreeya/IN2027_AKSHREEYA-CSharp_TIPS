namespace Assignments
{
    using InventoryManager.ConsoleService;
    using InventoryManager.Repository;
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
        internal static void Main(string[] args)
        {
            try
            {
                var repo = new Repo();
                var service = new Service();
                var userConsole = new InventoryManagerViewer();
                userConsole.Menu();
            }
            catch (Exception ex)
            {
                InventoryManagerViewer.ErrorMessage(InventoryManagerResource.ApplicationError + ex.Message + "\n" + InventoryManagerResource.PressKey);
                Console.ReadKey();
            }
        }
    }
}