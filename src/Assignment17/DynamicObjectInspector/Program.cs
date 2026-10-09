namespace DynamicObjectInspector;

/// <summary>
/// Provides the entry point for the Dynamic Object Inspector application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Serves as the entry point for the application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    private static void Main(string[] args)
    {
        var person = new Person();
        var inspector = new ObjectInspector();
        Console.WriteLine("Before Update:");
        inspector.DisplayValue(person);
        Console.WriteLine("Updating Object values");
        inspector.UpdateValue(person, "Age", 25);
        inspector.UpdateValue(person, "City", "Chicago");
        Console.WriteLine("After Update:");
        inspector.DisplayValue(person);
    }
}
