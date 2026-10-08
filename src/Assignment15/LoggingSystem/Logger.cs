using System.Collections.Concurrent;

namespace LoggingSystem;

/// <summary>
/// Provides thread-safe error logging functionality for multiple users.
/// </summary>
public static class Logger
{
    private const string LogDirectory = @"C:\Users\akshreeya.thiyagaraj.SOLITONTECH\source\repos\IN2027_AKSHREEYA-CSharp_TIPS\src\Assignment15\LoggingSystem\ErrorLogger";
    private static ConcurrentDictionary<string, object> fileLock = new ConcurrentDictionary<string, object>();

    /// <summary>
    /// Writes an error message to the specified user's log file.
    /// </summary>
    /// <param name="userName">Name of the user generating the error.</param>
    /// <param name="errorMessage">Error message to be logged.</param>
    public static void LogError(string userName, string errorMessage)
    {
        try
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }

            string fileName = Path.Combine(LogDirectory, $"{userName}_errors.txt");
            object lockFile = fileLock.GetOrAdd(fileName, _ => new object());

            lock (lockFile)
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($"{DateTime.UtcNow} - {errorMessage}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error while logging for {userName}: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while logging for {userName}: {ex.Message}");
        }
    }
}