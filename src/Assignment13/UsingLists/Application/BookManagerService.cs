using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingLists.Domain;
using UsingLists.Infrastructure;

namespace UsingLists.Application
{
    public class BookManagerService : IBookManagerService
    {
        private BookManagerRepository<Book> _bookManagerRepository;

        public BookManagerService(BookManagerRepository<Book> bookManagerRepository)
        {
            this._bookManagerRepository = bookManagerRepository;
        }

        public Result CreateBook(Book book)
        {
            if (this.DoesBookExists(book.Title))
            {
                return Result.Failure("Book already exists, Duplicates arent allowed");
            }

            this._bookManagerRepository.AddBook(book);
            return Result.Success("Book Added successfully");
        }

        public bool DoesBookExists(string bookTitle)
        {
            return this.GetAllBooks().Any(x => x.Title.Equals(bookTitle));
        }

        public bool ContainsBook(string bookTitle)
        {
            return this.DoesBookExists(bookTitle);
        }

        public bool DeleteBook(string bookTitle)
        {
            if (!this.DoesBookExists(bookTitle))
            {
                return false;
            }

            var book = this.GetAllBooks().FirstOrDefault(x => x.Title.Equals(bookTitle));
            if (book != null)
            {
                this._bookManagerRepository.RemoveBook(book);
                return true;
            }

            return false;
        }

        public IEnumerable<Book> GetAllBooks() => this._bookManagerRepository.GetBooks();
    }
}
