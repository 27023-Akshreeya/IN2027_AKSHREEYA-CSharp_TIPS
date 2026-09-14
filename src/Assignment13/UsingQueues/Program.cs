using UsingQueues.Application;
using UsingQueues.Domain;
using UsingQueues.Infrastructure;
using UsingQueues.Presentation;

namespace Assignments;

internal class Program
{
    static void Main(string[] args)
    {
        var repo = new PeopleQueueRepository<Person>();
        var service = new PeopleQueueService(repo);
        var view = new ConsoleUI(service);
        view.Run();
    }
}