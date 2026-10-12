using DisplayApp;
using ResultLogger;

namespace MathApp;

/// <summary>
/// Provides the entry point for the MathApp application.
/// </summary>
public class Program
{
    /// <summary>
    /// Serves as the entry point for the application.
    /// </summary>
    public static void Main()
    {
        IMathOperation mathOperation = new MathOperations();
        ILogger logger = new Logger();
        DisplayApp.Program.PerfromMathOperation(mathOperation, logger);
    }
}

/// <summary>
/// Provides methods for performing basic arithmetic operations.
/// </summary>
public class MathOperations : IMathOperation
{
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The sum.</returns>
    public int Add(int number1, int number2)
    {
        return number1 + number2;
    }

    /// <summary>
    /// Subtracts the second number from the first.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The difference.</returns>
    public int Subtract(int number1, int number2)
    {
        return number1 - number2;
    }

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The product.</returns>
    public int Multiply(int number1, int number2)
    {
        return number1 * number2;
    }

    /// <summary>
    /// Divides the first number by the second.
    /// </summary>
    /// <param name="number1">The dividend.</param>
    /// <param name="number2">The divisor.</param>
    /// <returns>The quotient.</returns>
    /// <exception cref="DivideByZeroException">Thrown when divisor is zero.</exception>
    public int Divide(int number1, int number2)
    {
        if (number2 == 0)
        {
            throw new DivideByZeroException();
        }

        return number1 / number2;
    }
}
