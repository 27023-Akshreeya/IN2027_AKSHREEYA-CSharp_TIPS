namespace UnderstandingRecords
{
    public record Book
    {
        public string Title { get; init; }
        public string Author { get; init; }
        public long ISBN { get; init; }

        public void Deconstruct(out string title, out string author, out long isbn)
        {
            title = this.Title;
            author = this.Author;
            isbn = this.ISBN;
        }
    }

    public record struct Novel(string title, string author, long isbn);
}
