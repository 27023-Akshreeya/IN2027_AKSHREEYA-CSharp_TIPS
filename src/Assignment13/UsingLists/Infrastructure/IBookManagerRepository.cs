using System.Collections.Generic;
using UsingLists.Domain;

namespace UsingLists.Infrastructure;

/// <summary>
/// Defines repository operation for managing books
/// </summary>
/// <typeparam name="TEntity">The type of book entity</typeparam>
/// <typeparam name="TId">The type of books value</typeparam>
public interface IBookManagerRepository<TEntity, TId>
    where TEntity : class, IIdentifier<TId>
{
    /// <summary>
    /// Adds a book entity to the repository.
    /// </summary>
    /// <param name="book">The book entity to add.</param>
    void AddBook(TEntity book);

    /// <summary>
    /// Gets all books from the collection.
    /// </summary>
    /// <returns>a collection of all books</returns>
    IEnumerable<TEntity> GetBooks();

    /// <summary>
    /// Removes the specified book from the collection.
    /// </summary>
    /// <param name="book">The book entity to remove.</param>
    void RemoveBook(TEntity book);
}