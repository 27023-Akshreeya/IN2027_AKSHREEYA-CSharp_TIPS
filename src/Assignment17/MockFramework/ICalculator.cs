/// <summary>
/// Defines mathematical and validation operations for testing.
/// </summary>
public interface ICalculator
{
    /// <summary>
    /// Adds two integers.
    /// </summary>
    /// <param name="number1">The first integer.</param>
    /// <param name="number2">The second integer.</param>
    /// <returns>The sum of the two integers.</returns>
    int Add(int number1, int number2);

    /// <summary>
    /// Checks whether the input is valid.
    /// </summary>
    /// <returns>True if valid; otherwise, false.</returns>
    bool IsValid();
}
