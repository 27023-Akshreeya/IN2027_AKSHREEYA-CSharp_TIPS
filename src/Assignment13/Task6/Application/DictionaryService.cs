namespace Task6.Application;

public class DictionaryService
{
    public IReadOnlyDictionary<string, int> GenerateDictionary()
    {
        Dictionary<string, int> dictionary = new ()
        {
            { "Apple", 5 },
            { "Banana", 10 },
            { "Orange", 15 },
        };

        return dictionary;
    }

    public void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        foreach (KeyValuePair<string, int> item in dictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
