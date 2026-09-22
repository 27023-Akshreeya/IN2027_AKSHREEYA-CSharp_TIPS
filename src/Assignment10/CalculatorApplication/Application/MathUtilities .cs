using System;

namespace CalculatorApplication.Application;

/// <summary>
/// Provides basic arithmetic utility methods.
/// </summary>
public class MathUtilities
{
    /// <summary>
    /// Calculates the sum of two integers.
    /// </summary>
    /// <param name="firstNumber">The first integer.</param>
    /// <param name="secondNumber">The second integer.</param>
    /// <returns>The sum result.</returns>
    public int Add(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber;
    }

    /// <summary>
    /// Calculates the difference between two integers.
    /// </summary>
    /// <param name="firstNumber">The first integer.</param>
    /// <param name="secondNumber">The second integer to subtract.</param>
    /// <returns>The difference result.</returns>
    public int Subtract(int firstNumber, int secondNumber)
    {
        return firstNumber - secondNumber;
    }

    /// <summary>
    /// Calculates the product of two integers.
    /// </summary>
    /// <param name="firstNumber">The first integer.</param>
    /// <param name="secondNumber">The second integer.</param>
    /// <returns>The product result.</returns>
    public int Multiply(int firstNumber, int secondNumber)
    {
        return firstNumber * secondNumber;
    }

    /// <summary>
    /// Calculates the quotient of two integers.
    /// </summary>
    /// <param name="firstNumber">The dividend.</param>
    /// <param name="secondNumber">The divisor.</param>
    /// <returns>The division result as a double.</returns>
    /// <exception cref="DivideByZeroException">Thrown when divisor is zero.</exception>
    public double Divide(int firstNumber, int secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Error: Division by zero is not allowed.");
        }

        return (double)firstNumber / secondNumber;
    }
}
