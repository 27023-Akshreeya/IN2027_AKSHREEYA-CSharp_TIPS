namespace UsingLists.Domain;

/// <summary>
/// Represents a book.
/// </summary>
public class Book
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Book"/> class.
    /// </summary>
    /// <param name="title">Book title.</param>
    public Book(string title)
    {
        this.Title = title;
    }

    /// <summary>
    /// Gets or sets the book title.
    /// </summary>
    /// <value>The book title.
    /// </value>
    public string Title { get; set; }
}
