using UsingQueues.Domain;
using UsingQueues.Infrastructure;

namespace UsingQueues.Application;

/// <summary>
/// Provides queue management operations for persons, including addition, removal, and retrieval.
/// </summary>
/// <typeparam name="T">The type representing a person in the queue.</typeparam>
public class PeopleQueueService<T> : IQueueService<T>
    where T : class
{
    private readonly PeopleQueueRepository<T> _peopleQueueRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PeopleQueueService{T}"/> class.
    /// </summary>
    /// <param name="peopleQueueRepository">People queue repository.</param>
    public PeopleQueueService(PeopleQueueRepository<T> peopleQueueRepository)
    {
        this._peopleQueueRepository = peopleQueueRepository;
    }

    /// <summary>
    /// Adds a new person to the queue.
    /// </summary>
    /// <param name="person">Person to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    public bool AddNewPerson(T person)
    {
        this._peopleQueueRepository.AddPerson(person);
        return true;
    }

    /// <summary>
    /// Removes and returns the first person in the queue.
    /// </summary>
    /// <returns>The removed person.</returns>
    public T RemoveFirstPerson()
    {
        return this._peopleQueueRepository.RemovePerson();
    }

    /// <summary>
    /// Retrieves all persons in the queue.
    /// </summary>
    /// <returns>A collection of persons.</returns>
    public IEnumerable<T> GetAllPersons() => this._peopleQueueRepository.GetPeople();
}
