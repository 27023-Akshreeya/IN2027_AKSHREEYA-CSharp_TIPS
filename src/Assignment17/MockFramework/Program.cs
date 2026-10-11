using System.Reflection;
using System.Reflection.Emit;

/// <summary>
/// Contains the entry point for testing the generated mock object.
/// </summary>
internal class Program
{
    /// <summary>
    /// Creates a mock calculator and displays its default return values.
    /// </summary>
    private static void Main()
    {
        ICalculator mock = MockGenerator.CreateMockCalculator();
        Console.WriteLine($"Add: {mock.Add(2, 3)}\nIsValid: {mock.IsValid()}");
    }
}