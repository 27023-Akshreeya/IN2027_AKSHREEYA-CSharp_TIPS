using UsingLists.Domain;

namespace UsingLists.Application
{
    public interface IBookManagerService
    {
        bool ContainsBook(string bookTitle);

        Result CreateBook(Book book);

        bool DeleteBook(string bookTitle);

        bool DoesBookExists(string bookTitle);

        IEnumerable<Book> GetAllBooks();
    }
}