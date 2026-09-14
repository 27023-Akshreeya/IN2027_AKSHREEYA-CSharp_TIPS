using Task6.Application;
using Task6.Presentation;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        var dictionaryService = new DictionaryService();
        var numberService = new NumberService();
        var viewer = new ConsoleUI(numberService, dictionaryService);
        viewer.Run();
    }
}