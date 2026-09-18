using System.Collections.Generic;

namespace Task6.Application;

/// <summary>
/// Provides number-related operations.
/// </summary>
public class NumberService
{
    /// <summary>
    /// Calculates the sum of elements.
    /// </summary>
    /// <param name="numbers">Collection of numbers.</param>
    /// <returns>The sum of all elements.</returns>
    public int SumOfElements(IEnumerable<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }
}
