using UsingQueues.Domain;

namespace UsingQueues.Application;

/// <summary>
/// Defines queue management operations.
/// </summary>
public interface IQueueService
{
    /// <summary>
    /// Adds a new person to the queue.
    /// </summary>
    /// <param name="person">Person to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    bool AddNewPerson(Person person);

    /// <summary>
    /// Retrieves all persons in the queue.
    /// </summary>
    /// <returns>A collection of persons.</returns>
    IEnumerable<Person> GetAllPersons();

    /// <summary>
    /// Removes and returns the first person in the queue.
    /// </summary>
    /// <returns>The removed person.</returns>
    Person RemoveFirstPerson();
}