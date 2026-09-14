namespace UsingQueues.Infrastructure;

public class PeopleQueueRepository<T>
{
    private readonly Queue<T> _people = new ();

    public void AddPerson(T person)
    {
        this._people.Enqueue(person);
    }

    public T RemovePerson()
    {
        return this._people.Dequeue();
    }

    public IEnumerable<T> GetPeople() => this._people;
}
