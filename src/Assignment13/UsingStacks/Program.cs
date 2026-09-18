using UsingStacks.Application;
using UsingStacks.Presentation;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the string reversal application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
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