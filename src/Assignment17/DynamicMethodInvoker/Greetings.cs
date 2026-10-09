namespace DynamicMethodInvoker;

/// <summary>
/// Provides greeting methods for different times of day.
/// </summary>
public class Greetings
{
    /// <summary>
    /// Displays Good morning greetings
    /// </summary>
    public void MorningGreets()
    {
        Console.WriteLine("Good morning!");
    }

    /// <summary>
    /// Displays good evening greetings
    /// </summary>
    public void EveningGreets()
    {
        Console.WriteLine("Good Evening!");
    }
}