using UsingDictionary.Application;
using UsingDictionary.Infrastructure;
using UsingDictionary.Presentation;

namespace Assignments;

internal class Program
{
    public static void Main(string[] args)
    {
        StudentGradeRepository<string, int> repository = new StudentGradeRepository<string, int>();
        StudentGradeService service = new StudentGradeService(repository);
        ConsoleUI consoleUI = new ConsoleUI(service);
        consoleUI.Menu();
    }
}