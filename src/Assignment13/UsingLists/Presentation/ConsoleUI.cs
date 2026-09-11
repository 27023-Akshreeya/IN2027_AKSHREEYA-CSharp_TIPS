using UsingLists.Application;
using UsingLists.Helper;

namespace UsingLists.Presentation
{
    public class ConsoleUI
    {
        private BookManagerService<string> _bookManagerService;

        public ConsoleUI(BookManagerService<string> bookManagerService)
        {
            this._bookManagerService = bookManagerService;
        }

        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(BookManagerResource.Menu);
                string choice = this.GetInputWithAttempts(BookManagerResource.Choice, InputValidator.IsChoiceValid, BookManagerResource.invalidChoice);
                switch (choice)
                {
                    case "1":
                        this.AddNewBooks();
                        break;
                    case "2":
                        this.RemoveBook();
                        break;
                    case "3":
                        this.SearchBook();
                        break;
                    case "4":
                        this.ViewAllBooks();
                        break;
                    case "5":
                        exit = true;
                        return;
                    default:
                        break;
                }

                string exitChoice = this.GetInputWithAttempts("Do you want to exit? [y/n]:", InputValidator.IsExitChoiceValid, BookManagerResource.invalidChoice);
                if (string.IsNullOrWhiteSpace(exitChoice))
                {
                    exit = true;
                }

                exit = exitChoice.Equals("y", StringComparison.OrdinalIgnoreCase);
            }
        }

        private void ViewAllBooks()
        {
            var books = this._bookManagerService.GetAllBooks();
            int bookCount = 0;
            Console.WriteLine("Book list");
            foreach (var book in books)
            {
                Console.WriteLine($"{bookCount + 1}. {book}");
                bookCount++;
            }
        }

        private void SearchBook()
        {
            string book = this.GetInputWithAttempts(BookManagerResource.SearchBook, input => !string.IsNullOrEmpty(input), BookManagerResource.invalidBook);
            if (string.IsNullOrWhiteSpace(book))
            {
                Console.WriteLine(BookManagerResource.invalidBook);
            }

            if (this._bookManagerService.FindBook(book))
            {
                Console.WriteLine($"{book} Found!");
            }
            else
            {
                Console.WriteLine("This book does not exists in this list");
            }
        }

        private void RemoveBook()
        {
            string bookTitle = this.GetInputWithAttempts("Enter book name to delete:", InputValidator.IsBookValid, BookManagerResource.invalidBook);
            if (this._bookManagerService.DeleteBook(bookTitle))
            {
                Console.WriteLine("Book is deleted successfull");
            }
            else
            {
                Console.WriteLine("Book does not exist");
            }
        }

        private void AddNewBooks()
        {
            Console.WriteLine(BookManagerResource.addBook);
            for (int bookCount = 0; bookCount < 5; bookCount++)
            {
                string book = this.GetInputWithAttempts(BookManagerResource.GetBook + $"no {bookCount + 1}: ", InputValidator.IsBookValid, BookManagerResource.invalidBook);
                if (string.IsNullOrWhiteSpace(book))
                {
                    Console.WriteLine($"Couldn't add book {book}!" +
                        $"Enter a valid book");
                    continue;
                }

                var result = this._bookManagerService.AddBook(book);
                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.Message);
                    continue;
                }

                Console.WriteLine(result.Message);
            }
        }

        private string GetInputWithAttempts(string input, InputValidation validator, string invalidInput)
        {
            for (int tries = 3; tries > 0; tries--)
            {
                Console.Write($"\nAttempts remaining: {tries}\n{input}");
                string userInput = Console.ReadLine() ?? string.Empty;
                if (validator(userInput))
                {
                    return userInput;
                }

                Console.WriteLine(invalidInput);
            }

            return string.Empty;
        }
    }
}
