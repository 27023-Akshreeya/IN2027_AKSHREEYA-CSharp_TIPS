namespace UsingDictionary.Infrastructure;

public class StudentGradeRepository<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _dictionary = new ();

    public void Add(TKey key, TValue value)
    {
        this._dictionary.Add(key, value);
    }

    public bool Remove(TKey key)
    {
        return this._dictionary.Remove(key);
    }

    public bool ContainsKey(TKey key)
    {
        return this._dictionary.ContainsKey(key);
    }

    public TValue Get(TKey key)
    {
        return this._dictionary[key];
    }

    public IEnumerable<KeyValuePair<TKey, TValue>> GetAllStudents()
    {
        return this._dictionary;
    }
}
