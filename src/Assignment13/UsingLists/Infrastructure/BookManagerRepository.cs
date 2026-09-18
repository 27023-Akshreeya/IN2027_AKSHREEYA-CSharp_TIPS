using System.Collections.Generic;
using UsingLists.Domain;

namespace UsingLists.Infrastructure;

/// <summary>
/// Repository for managing entity data.
/// </summary>
/// <typeparam name="TEntity">Type of book entity.</typeparam>
/// <typeparam name="TId">Type of the identifier value.</typeparam>
public class BookManagerRepository<TEntity, TId> : IBookManagerRepository<TEntity, TId>
    where TEntity : class, IIdentifier<TId>
{
    private readonly List<TEntity> _books;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookManagerRepository{TEntity, TId}"/> class.
    /// </summary>
    public BookManagerRepository()
    {
        this._books = new List<TEntity>();
    }

    /// <summary>
    /// Adds an entity to the repository.
    /// </summary>
    /// <param name="book">Entity to add.</param>
    public void AddBook(TEntity book)
    {
        this._books.Add(book);
    }

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <returns>The collection of entities.</returns>
    public IEnumerable<TEntity> GetBooks() => this._books;

    /// <summary>
    /// Removes an entity from the repository.
    /// </summary>
    /// <param name="book">Entity to remove.</param>
    public void RemoveBook(TEntity book)
    {
        this._books.Remove(book);
    }
}
