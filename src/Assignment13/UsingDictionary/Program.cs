using UsingDictionary.Application;
using UsingDictionary.Infrastructure;
using UsingDictionary.Presentation;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the student grade management application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        StudentGradeRepository<string, int> repository = new StudentGradeRepository<string, int>();
        StudentGradeService service = new StudentGradeService(repository);
        ConsoleUI consoleUI = new ConsoleUI(service);
        consoleUI.Menu();
    }
}