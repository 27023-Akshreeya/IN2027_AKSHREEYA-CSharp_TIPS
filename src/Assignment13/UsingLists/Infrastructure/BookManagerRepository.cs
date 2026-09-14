using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingLists.Domain;

namespace UsingLists.Infrastructure
{
    public class BookManagerRepository<T>
    {
        private readonly List<T> _books;

        public BookManagerRepository()
        {
            this._books = new List<T>();
        }

        public void AddBook(T book)
        {
            this._books.Add(book);
        }

        public IEnumerable<T> GetBooks() => this._books;

        internal void RemoveBook(T bookTitle)
        {
            this._books.Remove(bookTitle);
        }
    }
}
