namespace UsingQueues.Infrastructure;

/// <summary>
/// Repository for managing people in a queue.
/// </summary>
/// <typeparam name="T">Type of person entity.</typeparam>
public class PeopleQueueRepository<T>
{
    private readonly Queue<T> _people = new ();

    /// <summary>
    /// Adds a person to the queue.
    /// </summary>
    /// <param name="person">Person to add.</param>
    public void AddPerson(T person)
    {
        this._people.Enqueue(person);
    }

    /// <summary>
    /// Removes and returns the first person in the queue.
    /// </summary>
    /// <returns>The removed person.</returns>
    public T RemovePerson()
    {
        return this._people.Dequeue();
    }

    /// <summary>
    /// Retrieves all people in the queue.
    /// </summary>
    /// <returns>A collection of people.</returns>
    public IEnumerable<T> GetPeople() => this._people;
}
