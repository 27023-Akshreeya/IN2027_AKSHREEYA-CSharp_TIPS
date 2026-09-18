namespace UsingLists.Domain;

/// <summary>
/// Represents a book.
/// </summary>
public class Book : IIdentifier<string>
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
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the title of the current instance.
    /// </summary>
    /// <value> The title of the current instance.</placeholder>
    /// </value>
    public string Id => this.Title;
}
