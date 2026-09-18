using UsingQueues.Domain;

namespace UsingQueues.Application;

/// <summary>
/// Defines operations for managing a queue of persons.
/// </summary>
/// <typeparam name="T">The type of person in the queue.</typeparam>
public interface IQueueService<T>
    where T : class
{
    /// <summary>
    /// Adds a new person to the queue.
    /// </summary>
    /// <param name="item">Person to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    bool AddNewPerson(T item);

    /// <summary>
    /// Retrieves all persons in the queue.
    /// </summary>
    /// <returns>A collection of persons.</returns>
    IEnumerable<T> GetAllPersons();

    /// <summary>
    /// Removes and returns the first person in the queue.
    /// </summary>
    /// <returns>The removed person.</returns>
    T RemoveFirstPerson();
}