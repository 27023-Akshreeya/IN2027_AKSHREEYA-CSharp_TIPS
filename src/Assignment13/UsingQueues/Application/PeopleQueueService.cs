using UsingQueues.Domain;
using UsingQueues.Infrastructure;

namespace UsingQueues.Application;

/// <summary>
/// Provides queue management services.
/// </summary>
public class PeopleQueueService : IQueueService
{
    private readonly PeopleQueueRepository<Person> _peopleQueueRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PeopleQueueService"/> class.
    /// </summary>
    /// <param name="peopleQueueRepository">People queue repository.</param>
    public PeopleQueueService(PeopleQueueRepository<Person> peopleQueueRepository)
    {
        this._peopleQueueRepository = peopleQueueRepository;
    }

    /// <summary>
    /// Adds a new person to the queue.
    /// </summary>
    /// <param name="person">Person to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    public bool AddNewPerson(Person person)
    {
        this._peopleQueueRepository.AddPerson(person);
        return true;
    }

    /// <summary>
    /// Removes and returns the first person in the queue.
    /// </summary>
    /// <returns>The removed person.</returns>
    public Person RemoveFirstPerson()
    {
        return this._peopleQueueRepository.RemovePerson();
    }

    /// <summary>
    /// Retrieves all persons in the queue.
    /// </summary>
    /// <returns>A collection of persons.</returns>
    public IEnumerable<Person> GetAllPersons() => this._peopleQueueRepository.GetPeople();
}
