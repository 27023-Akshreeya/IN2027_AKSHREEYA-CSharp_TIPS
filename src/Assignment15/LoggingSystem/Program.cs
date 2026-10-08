namespace LoggingSystem;

/// <summary>
/// Entry point for testing concurrent user error logging.
/// </summary>
public class Program
{
    /// <summary>
    /// Simulates multiple users logging errors simultaneously.
    /// </summary>
    private static async Task Main()
    {
        var tasks = new List<Task>();
        for (int user = 1; user <= 5; user++)
        {
            int currentUser = user;
            for (int entry = 1; entry <= 5; entry++)
            {
                int currentEntry = entry;
                tasks.Add(Task.Run(() => Logger.LogError($"User{currentUser}", $"Error {currentEntry} occurred")));
            }
        }

        await Task.WhenAll(tasks);
        Console.WriteLine("All users logged successfully.");
    }
}