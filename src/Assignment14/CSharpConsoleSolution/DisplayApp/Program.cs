using UtilityApp;

namespace DisplayApp;

/// <summary>
/// Defines methods for mathematical operations.
/// </summary>
public interface IMathOperation
{
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The sum.</returns>
    int Add(int number1, int number2);

    /// <summary>
    /// Subtracts the second number from the first.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The difference.</returns>
    int Subtract(int number1, int number2);

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The product.</returns>
    int Multiply(int number1, int number2);

    /// <summary>
    /// Divides one integer by another and returns the quotient.
    /// </summary>
    /// <param name="number1">The dividend.</param>
    /// <param name="number2">The divisor. Cannot be zero.</param>
    /// <returns>The integer result of the division.</returns>
    int Divide(int number1, int number2);
}

/// <summary>
/// Defines methods for logging and retrieving mathematical operation results.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs the calculation data and result.
    /// </summary>
    /// <param name="number1">The first operand.</param>
    /// <param name="number2">The second operand.</param>
    /// <param name="operation">The operation string symbol.</param>
    /// <param name="result">The computed result value.</param>
    void LogResult(int number1, int number2, string operation, int result);

    /// <summary>
    /// Retrieves a list of all logged calculations.
    /// </summary>
    /// <returns>A list of history records.</returns>
    List<string> GetLoggedResults();
}

/// <summary>
/// Provides methods for user input, validation, and execution of mathematical operations with logging capabilities.
/// </summary>
public class Program
{
    /// <summary>
    /// Prompts for two numbers and validates each input.
    /// </summary>
    /// <returns>A tuple containing the two valid numbers as strings, or empty strings if validation fails.</returns>
    public static (string, string) GetUserInput()
    {
        Console.Write("Enter the first number:");
        string input1 = Console.ReadLine() ?? string.Empty;
        if (!InputValidator.IsValidNumber(input1))
        {
            Console.WriteLine("Invalid input. Please enter a valid number!");
            return (string.Empty, string.Empty);
        }

        Console.Write("Enter the second number:");
        string input2 = Console.ReadLine() ?? string.Empty;
        if (!InputValidator.IsValidNumber(input2))
        {
            Console.WriteLine("Invalid input. Please enter a valid number!");
            return (string.Empty, string.Empty);
        }

        return (input1, input2);
    }

    /// <summary>
    /// Executes a mathematical operation based on user input and logs the result.
    /// </summary>
    /// <param name="mathOperation">Performs the specified mathematical calculations.</param>
    /// <param name="logger">Logs the results of the mathematical operation.</param>
    public static void PerfromMathOperation(IMathOperation mathOperation, ILogger logger)
    {
        Console.WriteLine("Performing math operation");
        var (input1, input2) = GetUserInput();
        if (input1 == string.Empty || input2 == string.Empty)
        {
            return;
        }

        Console.Write("Enter the math operation (+, -, *, /):");
        string operation = Console.ReadLine() ?? string.Empty;
        if (!InputValidator.IsValidOperation(operation))
        {
            Console.WriteLine("Invalid operation. Please enter a valid operation!");
            return;
        }

        int number1 = int.Parse(input1);
        int number2 = int.Parse(input2);
        int result = 0;
        switch (operation)
        {
            case "+":
                Console.WriteLine("Performing addition");
                result = mathOperation.Add(number1, number2);
                break;
            case "-":
                Console.WriteLine("Performing subtraction");
                result = mathOperation.Subtract(number1, number2);
                break;
            case "*":
                Console.WriteLine("Performing multiplication");
                result = mathOperation.Multiply(number1, number2);
                break;
            case "/":
                Console.WriteLine("Performing division");
                result = mathOperation.Divide(number1, number2);
                break;
            default:
                Console.WriteLine("Invalid operation!");
                return;
        }

        DisplayResult(result);
        logger.LogResult(number1, number2, operation, result);
        Console.Write("Do you want to see the logged results? (y/n) :");
        string showLoggedResults = Console.ReadLine() ?? string.Empty;
        if (showLoggedResults.ToLower() == "y")
        {
            DisplayLoggedResults(logger);
        }
    }

    /// <summary>
    /// Prints the computation result to the console screen.
    /// </summary>
    /// <param name="result">The calculation output integer value.</param>
    private static void DisplayResult(int result)
    {
        Console.WriteLine($"The result is: {result}");
    }

    /// <summary>
    /// Renders the collection of historical audit items from the logging provider.
    /// </summary>
    /// <param name="logger">The system transaction data engine context provider.</param>
    private static void DisplayLoggedResults(ILogger logger)
    {
        Console.WriteLine("Logged Results:");
        var loggedResults = logger.GetLoggedResults();
        if (loggedResults.Count == 0)
        {
            Console.WriteLine("No results logged yet.");
            return;
        }

        foreach (var log in loggedResults)
        {
            Console.WriteLine(log);
        }
    }

    private static void Main(string[] args)
    {
    }
}
