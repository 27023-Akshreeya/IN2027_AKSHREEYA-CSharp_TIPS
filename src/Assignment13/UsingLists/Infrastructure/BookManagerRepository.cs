using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLists.Infrastructure
{
    public class BookManagerRepository<T>
    {
        private readonly List<T> _books;

        public BookManagerRepository()
        {
            this._books = new List<T>();
        }

        public void Add(T book)
        {
            this._books.Add(book);
        }

        public IReadOnlyList<T> GetBooks() => this._books;

        internal void Remove(T bookTitle)
        {
            this._books.Remove(bookTitle);
        }
    }
}
