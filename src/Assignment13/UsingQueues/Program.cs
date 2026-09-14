using UsingQueues.Application;
using UsingQueues.Domain;
using UsingQueues.Infrastructure;
using UsingQueues.Presentation;

namespace Assignments;

/// <summary>
/// Entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Starts the queue management application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        var repo = new PeopleQueueRepository<Person>();
        var service = new PeopleQueueService(repo);
        var view = new ConsoleUI(service);
        view.Run();
    }
}