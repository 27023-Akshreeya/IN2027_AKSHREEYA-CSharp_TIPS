namespace UsingLists.Infrastructure;

/// <summary>
/// Repository for managing book data.
/// </summary>
/// <typeparam name="T">Type of book entity.</typeparam>
public class BookManagerRepository<T>
{
    private readonly List<T> _books;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookManagerRepository{T}"/> class.
    /// Initializes a new repository instance.
    /// </summary>
    public BookManagerRepository()
    {
        this._books = new List<T>();
    }

    /// <summary>
    /// Adds a book to the repository.
    /// </summary>
    /// <param name="book">Book to add.</param>
    public void AddBook(T book)
    {
        this._books.Add(book);
    }

    /// <summary>
    /// Retrieves all books.
    /// </summary>
    /// <returns>The collection of books.</returns>
    public IEnumerable<T> GetBooks() => this._books;

    /// <summary>
    /// Removes a book from the repository.
    /// </summary>
    /// <param name="bookTitle">Book to remove.</param>
    internal void RemoveBook(T bookTitle)
    {
        this._books.Remove(bookTitle);
    }
}
