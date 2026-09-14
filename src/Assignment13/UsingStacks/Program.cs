using UsingStacks.Application;
using UsingStacks.Presentation;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var stackService = new StackService<char>();
                var reversalService = new StringReversalService(stackService);
                var viewer = new ConsoleUI(reversalService);
                viewer.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}