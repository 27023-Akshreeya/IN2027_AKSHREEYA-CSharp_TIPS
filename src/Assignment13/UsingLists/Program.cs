using UsingLists.Application;
using UsingLists.Infrastructure;
using UsingLists.Presentation;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var repo = new BookManagerRepository<string>();
            var service = new BookManagerService<string>(repo);
            var view = new ConsoleUI(service);
            view.Menu();
        }
    }
}