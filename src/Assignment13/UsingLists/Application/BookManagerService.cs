using UsingLists.Domain;
using UsingLists.Infrastructure;

namespace UsingLists.Application;

/// <summary>
/// Provides book management services.
/// </summary>
public class BookManagerService : IBookManagerService
{
    private BookManagerRepository<Book> _bookManagerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookManagerService"/> class.
    /// </summary>
    /// <param name="bookManagerRepository">Book repository.</param>
    public BookManagerService(BookManagerRepository<Book> bookManagerRepository)
    {
        this._bookManagerRepository = bookManagerRepository;
    }

    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <returns>The operation result.</returns>
    public Result CreateBook(Book book)
    {
        if (this.DoesBookExists(book.Title))
        {
            return Result.Failure("Book already exists, Duplicates arent allowed");
        }

        this._bookManagerRepository.AddBook(book);
        return Result.Success("Book Added successfully");
    }

    /// <summary>
    /// Checks whether a book exists.
    /// </summary>
    /// <param name="bookTitle">Book title.</param>
    /// <returns>True if the book exists; otherwise, false.</returns>
    public bool DoesBookExists(string bookTitle)
    {
        return this.GetAllBooks().Any(x => x.Title.Equals(bookTitle));
    }

    /// <summary>
    /// Checks whether a book exists.
    /// </summary>
    /// <param name="bookTitle">Book title.</param>
    /// <returns>True if the book exists; otherwise, false.</returns>
    public bool ContainsBook(string bookTitle)
    {
        return this.DoesBookExists(bookTitle);
    }

    /// <summary>
    /// Deletes a book.
    /// </summary>
    /// <param name="bookTitle">Book title.</param>
    /// <returns>True if deleted; otherwise, false.</returns>
    public bool DeleteBook(string bookTitle)
    {
        if (!this.DoesBookExists(bookTitle))
        {
            return false;
        }

        var book = this.GetAllBooks().FirstOrDefault(x => x.Title.Equals(bookTitle));
        if (book != null)
        {
            this._bookManagerRepository.RemoveBook(book);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Retrieves all books.
    /// </summary>
    /// <returns>A collection of books.</returns>
    public IEnumerable<Book> GetAllBooks() => this._bookManagerRepository.GetBooks();
}
