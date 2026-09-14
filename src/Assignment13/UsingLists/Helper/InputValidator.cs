namespace UsingLists.Helper;

/// <summary>
/// Represents an input validation method.
/// </summary>
/// <param name="input">Input to validate.</param>
/// <returns>True if valid; otherwise, false.</returns>
public delegate bool InputValidation(string input);

/// <summary>
/// Provides input validation methods.
/// </summary>
public static class InputValidator
{
    /// <summary>
    /// Validates a menu choice.
    /// </summary>
    /// <param name="input">User input.</param>
    /// <returns>True if the choice is valid; otherwise, false.</returns>
    public static bool IsChoiceValid(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length != 1)
        {
            return false;
        }

        return int.TryParse(input, out int choice) && choice > 0 && choice <= 5;
    }

    /// <summary>
    /// Validates a book name.
    /// </summary>
    /// <param name="input">Book name.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsBookValid(string input)
    {
        return !string.IsNullOrEmpty(input);
    }

    /// <summary>
    /// Validates an exit choice.
    /// </summary>
    /// <param name="input">User input.</param>
    /// <returns>True if the choice is valid; otherwise, false.</returns>
    public static bool IsExitChoiceValid(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length != 1)
        {
            return false;
        }

        return input.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                 input.Equals("y", StringComparison.OrdinalIgnoreCase);
    }
}
