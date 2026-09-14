using UsingQueues.Domain;

namespace UsingQueues.Application;

public interface IQueueService
{
    bool AddNewPerson(Person person);

    IEnumerable<Person> GetAllPersons();

    Person RemoveFirstPerson();
}