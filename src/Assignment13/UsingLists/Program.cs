using UsingLists.Application;
using UsingLists.Domain;
using UsingLists.Infrastructure;
using UsingLists.Presentation;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the book management application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        var bookRepository = new BookManagerRepository<Book>();
        IBookManagerService bookManagerService = new BookManagerService(bookRepository);
        var view = new ConsoleUI(bookManagerService);
        view.Menu();
    }
}