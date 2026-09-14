using UsingLists.Domain;

namespace UsingLists.Application;

/// <summary>
/// Defines book management operations.
/// </summary>
public interface IBookManagerService
{
    /// <summary>
    /// Checks whether a book exists.
    /// </summary>
    /// <param name="bookTitle">Book title.</param>
    /// <returns>True if the book exists; otherwise, false.</returns>
    bool ContainsBook(string bookTitle);

    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="book">Book to create.</param>
    /// <returns>The operation result.</returns>
    Result CreateBook(Book book);

    /// <summary>
    /// Deletes a book.
    /// </summary>
    /// <param name="bookTitle">Book title.</param>
    /// <returns>True if deleted; otherwise, false.</returns>
    bool DeleteBook(string bookTitle);

    /// <summary>
    /// Checks whether a book exists.
    /// </summary>
    /// <param name="bookTitle">Book title.</param>
    /// <returns>True if the book exists; otherwise, false.</returns>
    bool DoesBookExists(string bookTitle);

    /// <summary>
    /// Retrieves all books.
    /// </summary>
    /// <returns>A collection of books.</returns>
    IEnumerable<Book> GetAllBooks();
}