using UsingLists.Application;
using UsingLists.Domain;
using UsingLists.Helper;

namespace UsingLists.Presentation;

/// <summary>
/// Handles user interactions for book management.
/// </summary>
public class ConsoleUI
{
    private IBookManagerService _bookManagerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
    /// </summary>
    /// <param name="bookManagerService">Book management service.</param>
    public ConsoleUI(IBookManagerService bookManagerService)
    {
        this._bookManagerService = bookManagerService;
    }

    /// <summary>
    /// Displays the main menu.
    /// </summary>
    public void Menu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine(BookManagerResource.Menu);
            string choice = this.GetInputWithAttempts(BookManagerResource.Choice, InputValidator.IsChoiceValid, BookManagerResource.invalidChoice);
            switch (choice)
            {
                case "1":
                    this.AddNewBooks();
                    break;
                case "2":
                    this.RemoveBook();
                    break;
                case "3":
                    this.SearchBook();
                    break;
                case "4":
                    this.ViewAllBooks();
                    break;
                case "5":
                    exit = true;
                    return;
                default:
                    break;
            }

            string exitChoice = this.GetInputWithAttempts("Do you want to exit? [y/n]:", InputValidator.IsExitChoiceValid, BookManagerResource.invalidChoice);
            if (string.IsNullOrWhiteSpace(exitChoice))
            {
                exit = true;
            }

            exit = exitChoice.Equals("y", StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Displays all books.
    /// </summary>
    private void ViewAllBooks()
    {
        var books = this._bookManagerService.GetAllBooks();
        int bookCount = 0;
        Console.WriteLine("Book list");
        foreach (var book in books)
        {
            Console.WriteLine($"{bookCount + 1}. {book.Title}");
            bookCount++;
        }
    }

    /// <summary>
    /// Prompts the user to enter a book title and checks if it exists in the book manager.
    /// </summary>
    /// <remarks>Displays a message if the input is invalid or if the book is not found.</remarks>
    private void SearchBook()
    {
        string book = this.GetInputWithAttempts(BookManagerResource.SearchBook, input => !string.IsNullOrEmpty(input), BookManagerResource.invalidBook);
        if (string.IsNullOrWhiteSpace(book))
        {
            Console.WriteLine(BookManagerResource.invalidBook);
            return;
        }

        if (this._bookManagerService.ContainsBook(book))
        {
            Console.WriteLine($"{book} Found!");
        }
        else
        {
            Console.WriteLine("This book does not exists in this list");
        }
    }

    /// <summary>
    /// Removes a book.
    /// </summary>
    private void RemoveBook()
    {
        string bookTitle = this.GetInputWithAttempts("Enter book name to delete:", InputValidator.IsBookValid, BookManagerResource.invalidBook);
        if (!string.IsNullOrEmpty(bookTitle) && this._bookManagerService.DeleteBook(bookTitle))
        {
            Console.WriteLine("Book is deleted successfull");
        }
        else
        {
            Console.WriteLine("Book does not exist");
        }
    }

    /// <summary>
    /// Adds new books.
    /// </summary>
    private void AddNewBooks()
    {
        Console.WriteLine(BookManagerResource.addBook);
        for (int bookCount = 0; bookCount < 5; bookCount++)
        {
            string book = this.GetInputWithAttempts(BookManagerResource.GetBook + $"no {bookCount + 1}: ", InputValidator.IsBookValid, BookManagerResource.invalidBook);
            if (string.IsNullOrWhiteSpace(book))
            {
                Console.WriteLine($"Couldn't add book {book}!" +
                    $"Enter a valid book");
                continue;
            }

            var result = this._bookManagerService.CreateBook(new Book(book));
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Message);
                continue;
            }

            Console.WriteLine(result.Message);
        }
    }

    /// <summary>
    /// Gets validated input from the user.
    /// </summary>
    /// <param name="input">Input prompt.</param>
    /// <param name="validator">Input validator.</param>
    /// <param name="invalidInput">Invalid input message.</param>
    /// <returns>The validated input.</returns>
    private string GetInputWithAttempts(string input, InputValidation validator, string invalidInput)
    {
        for (int tries = 3; tries > 0; tries--)
        {
            Console.Write($"\nAttempts remaining: {tries}\n{input}");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (validator(userInput))
            {
                return userInput;
            }

            Console.WriteLine(invalidInput);
        }

        return string.Empty;
    }
}
