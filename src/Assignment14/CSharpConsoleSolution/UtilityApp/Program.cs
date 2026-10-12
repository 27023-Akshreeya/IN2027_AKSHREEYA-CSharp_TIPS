namespace UtilityApp;

/// <summary>
/// Provides the entry point for the UtilityApp application.
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
/// Provides utility methods to validate console user inputs.
/// </summary>
public static class InputValidator
{
    /// <summary>
    /// Checks if a string can be parsed into a valid integer.
    /// </summary>
    /// <param name="number">The string value to evaluate.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsValidNumber(string number)
    {
        return int.TryParse(number, out _);
    }

    /// <summary>
    /// Verifies if a string is a supported mathematical operator.
    /// </summary>
    /// <param name="operation">The string operator to check.</param>
    /// <returns>True if supported; otherwise, false.</returns>
    public static bool IsValidOperation(string operation)
    {
        return operation == "+" || operation == "-" || operation == "*" || operation == "/";
    }
}
