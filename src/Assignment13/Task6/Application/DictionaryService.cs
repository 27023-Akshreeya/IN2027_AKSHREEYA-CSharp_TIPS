namespace Task6.Application;

/// <summary>
/// Provides dictionary-related operations.
/// </summary>
public class DictionaryService
{
    /// <summary>
    /// Creates a sample dictionary.
    /// </summary>
    /// <returns>A read-only dictionary.</returns>
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

    /// <summary>
    /// Displays dictionary contents.
    /// </summary>
    /// <param name="dictionary">Dictionary to display.</param>
    public void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        foreach (KeyValuePair<string, int> item in dictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
