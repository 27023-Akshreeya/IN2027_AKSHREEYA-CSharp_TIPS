using UsingLists.Application;
using UsingLists.Domain;
using UsingLists.Infrastructure;
using UsingLists.Presentation;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var bookRepository = new BookManagerRepository<Book>();
            IBookManagerService bookManagerService = new BookManagerService(bookRepository);
            var view = new ConsoleUI(bookManagerService);
            view.Menu();
        }
    }
}