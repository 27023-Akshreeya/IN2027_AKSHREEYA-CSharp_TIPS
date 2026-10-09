using System.Reflection;

namespace InspectAssemblyMetadata;

/// <summary>
/// Entry point of the application
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        string dllPath = @"C:\Users\akshreeya.thiyagaraj.SOLITONTECH\source\repos\IN2027_AKSHREEYA-CSharp_TIPS\src\Assignment17\ProductManager\bin\Debug\net6.0\ProductManager.dll";

        try
        {
            var loadAssembly = Assembly.LoadFile(dllPath);
            var allTypes = loadAssembly.GetTypes();
            Console.WriteLine("All types in the assembly");
            foreach (var type in allTypes)
            {
                Console.WriteLine($"Found type : {type.FullName}");
                GetTypeInformation(type);
                Console.WriteLine(Environment.NewLine);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The specified file could not be found.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path must be an absolute path.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void GetTypeInformation(Type type)
    {
        Console.WriteLine("  Methods:");
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                      BindingFlags.Instance | BindingFlags.Static);

        foreach (var method in methods)
        {
            Console.WriteLine($"    {method.Name}");
        }

        Console.WriteLine("  Properties:");
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic |
                                            BindingFlags.Instance | BindingFlags.Static);

        foreach (var property in properties)
        {
            Console.WriteLine($"    {property.Name}");
        }

        Console.WriteLine("  Fields:");
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                    BindingFlags.Instance | BindingFlags.Static);

        foreach (var field in fields)
        {
            Console.WriteLine($"    {field.Name}");
        }

        Console.WriteLine("  Events:");
        var events = type.GetEvents(BindingFlags.Public | BindingFlags.NonPublic |
                                    BindingFlags.Instance | BindingFlags.Static);

        foreach (var evt in events)
        {
            Console.WriteLine($"    {evt.Name}");
        }
    }
}