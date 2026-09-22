namespace UnderstandingRecords
{
    /// <summary>
    /// Represents a book using a record type.
    /// </summary>
    public record Book
    {
        /// <summary>
        /// Gets the book title.
        /// </summary>
        /// <value>The book title.
        /// </value>
        public string Title { get; init; }

        /// <summary>
        /// Gets the author name.
        /// </summary>
        /// <value>The author name.</placeholder>
        /// </value>
        public string Author { get; init; }

        /// <summary>
        /// Gets the ISBN number.
        /// </summary>
        /// <value>The ISBN number.</placeholder>
        /// </value>
        public long ISBN { get; init; }

        /// <summary>
        /// Deconstructs the book into individual values.
        /// </summary>
        /// <param name="title">Book title.</param>
        /// <param name="author">Author name.</param>
        /// <param name="isbn">ISBN number.</param>
        public void Deconstruct(out string title, out string author, out long isbn)
        {
            title = this.Title;
            author = this.Author;
            isbn = this.ISBN;
        }
    }

    /// <summary>
    /// Represents a novel using a record struct.
    /// </summary>
    /// <param name="title">Novel title.</param>
    /// <param name="author">Author name.</param>
    /// <param name="isbn">ISBN number.</param>
    public record struct Novel(string title, string author, long isbn);
}
