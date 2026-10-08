using DisplayApp;

namespace ResultLogger;

/// <summary>
/// Provides the entry point for the ResultLogger application.
/// </summary>
public class Program
{
    /// <summary>
    /// Serves as the entry point for the application.
    /// </summary>
    private static void Main()
    {
    }
}

/// <summary>
/// Provides functionality to log operation results to a CSV file and retrieve logged entries.
/// </summary>
public class Logger : ILogger
{
    private const string FilePath = "ResultLogger.csv";

    /// <summary>
    /// Initializes a new instance of the <see cref="Logger"/> class and creates the log file with a header if it does not exist.
    /// </summary>
    public Logger()
    {
        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "Time Stamp,Number1,Number2,Operation,Result" + Environment.NewLine);
        }
    }

    /// <summary>
    /// Appends the arithmetic inputs, operator, and final outcome to the CSV file.
    /// </summary>
    /// <param name="number1">The first calculation input.</param>
    /// <param name="number2">The second calculation input.</param>
    /// <param name="operation">The math operation character used.</param>
    /// <param name="result">The computed result value.</param>
    public void LogResult(int number1, int number2, string operation, int result)
    {
        string logEntry = $"{DateTime.Now},{number1},{number2},{operation},{result}";
        File.AppendAllText(FilePath, logEntry + Environment.NewLine);
    }

    /// <summary>
    /// Reads and returns all logged transaction records from the CSV file.
    /// </summary>
    /// <returns>A list of past string entries without the header.</returns>
    public List<string> GetLoggedResults()
    {
        if (!File.Exists(FilePath))
        {
            return new List<string>();
        }

        return File.ReadAllLines(FilePath).Skip(1).ToList();
    }
}
