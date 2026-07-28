using InventoryManager.View;

namespace Assignments
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                UserConsole userConsole = new UserConsole();
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