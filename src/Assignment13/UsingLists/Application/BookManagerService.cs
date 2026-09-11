using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingLists.Domain;
using UsingLists.Infrastructure;

namespace UsingLists.Application
{
    public class BookManagerService<T>
    {
        private BookManagerRepository<T> _bookManagerRepository;

        public BookManagerService(BookManagerRepository<T> bookManagerRepository)
        {
            this._bookManagerRepository = bookManagerRepository;
        }

        public Result AddBook(T book)
        {
            if (this.DoesBookExists(book))
            {
                return Result.Failure("Book already exists, Duplicates arent allowed");
            }

            this._bookManagerRepository.Add(book);
            return Result.Success("Book Added successfully");
        }

        public bool DoesBookExists(T book)
        {
            return this.GetAllBooks().Any(x => x != null && x.Equals(book));
        }

        public IReadOnlyList<T> GetAllBooks() => this._bookManagerRepository.GetBooks();

        public bool FindBook(T book)
        {
            return this.DoesBookExists(book);
        }

        public bool DeleteBook(T bookTitle)
        {
            if (!this.DoesBookExists(bookTitle))
            {
                return false;
            }

            this._bookManagerRepository.Remove(bookTitle);
            return true;
        }
    }
}
