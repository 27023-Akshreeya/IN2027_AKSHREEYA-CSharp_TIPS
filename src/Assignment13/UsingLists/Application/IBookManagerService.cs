using System.Collections.Generic;
using UsingLists.Domain;

namespace UsingLists.Application;

/// <summary>
/// Defines service operations for managing book entities.
/// </summary>
/// <typeparam name="TEntity">The type of the book entity.</typeparam>
/// <typeparam name="TId">The type of the book's lookup identifier.</typeparam>
public interface IBookManagerService<TEntity, TId>
    where TEntity : class
{
    /// <summary>
    /// Creates a new book.
    /// </summary>
    /// <param name="item">The book instance to create.</param>
    /// <returns>A <see cref="bool"/> indicating success or failure.</returns>
    bool CreateBook(TEntity item);

    /// <summary>
    /// Deletes a book using its identifier value.
    /// </summary>
    /// <param name="value">The identifier value of the book to delete.</param>
    /// <returns><see langword="true"/> if deleted; otherwise, <see langword="false"/>.</returns>
    bool DeleteBook(TId value);

    /// <summary>
    /// Checks whether a book exists with the specified identifier value.
    /// </summary>
    /// <param name="value">The identifier value to look up.</param>
    /// <returns><see langword="true"/> if the book exists; otherwise, <see langword="false"/>.</returns>
    bool DoesBookExists(TId value);

    /// <summary>
    /// Retrieves all books.
    /// </summary>
    /// <returns>A collection of all books.</returns>
    IEnumerable<TEntity> GetAllBooks();
}
