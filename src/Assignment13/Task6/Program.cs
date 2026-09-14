using Task6.Application;
using Task6.Presentation;

namespace Assignments;

internal class Program
{
    static void Main(string[] args)
    {
        var dictionaryService = new DictionaryService();
        var numberService = new NumberService();
        var viewer = new ConsoleUI(numberService, dictionaryService);
        viewer.Run();
    }
}