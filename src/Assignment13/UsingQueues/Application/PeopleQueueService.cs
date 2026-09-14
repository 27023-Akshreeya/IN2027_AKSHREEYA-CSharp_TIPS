using UsingQueues.Domain;
using UsingQueues.Infrastructure;

namespace UsingQueues.Application;

public class PeopleQueueService : IQueueService
{
    private readonly PeopleQueueRepository<Person> _peopleQueueRepository;

    public PeopleQueueService(PeopleQueueRepository<Person> peopleQueueRepository)
    {
        this._peopleQueueRepository = peopleQueueRepository;
    }

    public bool AddNewPerson(Person person)
    {
        this._peopleQueueRepository.AddPerson(person);
        return true;
    }

    public Person RemoveFirstPerson()
    {
        return this._peopleQueueRepository.RemovePerson();
    }

    public IEnumerable<Person> GetAllPersons() => this._peopleQueueRepository.GetPeople();
}
