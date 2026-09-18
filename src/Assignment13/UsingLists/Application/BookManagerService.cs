using System.Collections.Generic;
using System.Linq;
using UsingLists.Domain;
using UsingLists.Infrastructure;

namespace UsingLists.Application;

/// <summary>
/// Service from managing business logic
/// </summary>
/// <typeparam name="TEntity">Book entity</typeparam>
/// <typeparam name="TId">Books value</typeparam>
public class BookManagerService<TEntity, TId> : IBookManagerService<TEntity, TId>
    where TEntity : class, IIdentifier<TId>
{
    private BookManagerRepository<TEntity, TId> _bookManagerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookManagerService{TEntity, TId}"/> class.
    /// </summary>
    /// <param name="bookManagerRepository">InfrastructureLayer object</param>
    public BookManagerService(BookManagerRepository<TEntity, TId> bookManagerRepository)
    {
        this._bookManagerRepository = bookManagerRepository;
    }

    /// <summary>
    /// Creates a new book if it does not already exist.
    /// </summary>
    /// <param name="newBook">The book entity to add.</param>
    /// <returns>A result indicating whether the operation succeeded or failed.</returns>
    public bool CreateBook(TEntity newBook)
    {
        if (this.DoesBookExists(newBook.Id))
        {
            return false;
        }

        this._bookManagerRepository.AddBook(newBook);
        return true;
    }

    /// <summary>
    /// Determines whether the specified book exists in the collection.
    /// </summary>
    /// <param name="book">The book in the collection.</param>
    /// <returns>true if the book exists; otherwise, false.</returns>
    public bool DoesBookExists(TId book)
    {
        return this.GetAllBooks().Any(x => x.Id.Equals(book));
    }

    /// <summary>
    /// Removes the specified book from the collection if it exists.
    /// </summary>
    /// <param name="deleteBook">The book to remove.</param>
    /// <returns>true if the book was removed; otherwise, false.</returns>
    public bool DeleteBook(TId deleteBook)
    {
        if (!this.DoesBookExists(deleteBook))
        {
            return false;
        }

        var book = this.GetAllBooks().FirstOrDefault(x => x.Id.Equals(deleteBook));
        if (book != null)
        {
            this._bookManagerRepository.RemoveBook(book);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Retrieves all books from the repository.
    /// </summary>
    /// <returns>An enumerable collection of book entities.</returns>
    public IEnumerable<TEntity> GetAllBooks() => this._bookManagerRepository.GetBooks();
}
