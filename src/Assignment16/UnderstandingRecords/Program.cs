using System;

namespace UnderstandingRecords
{
    /// <summary>
    /// Entry point for demonstrating record features.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs record class and record struct examples.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        private static void Main(string[] args)
        {
            var book1 = new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                ISBN = 9780061120084,
            };
            DisplayBook(book1);
            var book2 = new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                ISBN = 9780061120084,
            };
            DisplayBook(book2);
            var book3 = new Book
            {
                Title = "1984",
                Author = "George Orwell",
                ISBN = 9780451524935,
            };
            DisplayBook(book3);

            CheckEquality(book1, book2);
            UpdateBook(book3);

            var novel1 = new Novel("Pride and Prejudice", "Jane Austen", 9780141439518);
            UpdateNovel(novel1);
        }

        /// <summary>
        /// Demonstrates mutability of a record struct.
        /// </summary>
        /// <param name="novel">Novel to update.</param>
        private static void UpdateNovel(Novel novel)
        {
            Console.WriteLine("Mutablity of record struct");
            DisplayNovel(novel);
            novel.title = "Mansfield Park"; // will not throw compile time error
            Console.WriteLine("After changing");
            DisplayNovel(novel);
        }

        /// <summary>
        /// Demonstrates non-destructive mutation using the with keyword.
        /// </summary>
        /// <param name="book">Book to copy and modify.</param>
        private static void UpdateBook(Book book)
        {
            Console.WriteLine("Mutablity of record class");

            // book3.isbn = 9780547928237;
            // above snippet would throw an error because the property is set as "init" only and
            // cant be changed unless explicitly declared to "set".
            Console.WriteLine("Update book using \"with\" keyword");
            var copyBook = book;
            var modifyCopy = copyBook with { Title = "Animal Farm", ISBN = 9780451012890 };
            Console.WriteLine("Original Book");
            DisplayBook(book);
            Console.WriteLine("Modifiyed copy of the book");
            DisplayBook(modifyCopy);
        }

        /// <summary>
        /// Compares books by value and reference.
        /// </summary>
        /// <param name="book1">First book.</param>
        /// <param name="book2">Second book.</param>
        private static void CheckEquality(Book book1, Book book2)
        {
            Console.WriteLine("Checking equality of book values");
            if (book1 == book2)
            {
                Console.WriteLine("Both books consists of same values");
            }
            else
            {
                Console.WriteLine("Both book values are different");
            }

            Console.WriteLine("Checking equality of book references");
            if (ReferenceEquals(book1, book2))
            {
                Console.WriteLine("Reference of the books are same");
            }
            else
            {
                Console.WriteLine("Reference of the books are not same");
            }
        }

        /// <summary>
        /// Displays book details.
        /// </summary>
        /// <param name="book">Book to display.</param>
        private static void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine($"[Book ISBN : {isbn}]Book title: {title} written by {author}");
        }

        /// <summary>
        /// Displays novel details.
        /// </summary>
        /// <param name="novel">Novel to display.</param>
        private static void DisplayNovel(Novel novel)
        {
            Console.WriteLine($"[Book ISBN : {novel.isbn}]Book title: {novel.title} written by {novel.author}");
        }
    }
}