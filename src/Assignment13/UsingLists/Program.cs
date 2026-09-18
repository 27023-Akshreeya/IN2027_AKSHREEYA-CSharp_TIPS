using System;
using UsingLists.Application;
using UsingLists.Domain;
using UsingLists.Infrastructure;
using UsingLists.Presentation;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Starts the book management application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        try
        {
            var bookRepository = new BookManagerRepository<Book, string>();
            var bookManagerService = new BookManagerService<Book, string>(bookRepository);
            var view = new ConsoleUI(bookManagerService);
            view.Menu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}