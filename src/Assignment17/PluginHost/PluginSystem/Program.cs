using System.Reflection;
using PluginBase;

/// <summary>
/// Entry point for the application that loads and executes plugins from a specified directory.
/// </summary>
internal class Program
{
    private static void Main()
    {
        string pluginDirectory = Path.Combine(AppContext.BaseDirectory, @"C:\\Users\\akshreeya.thiyagaraj.SOLITONTECH\\source\\repos\\IN2027_AKSHREEYA-CSharp_TIPS\\src\\Assignment17\\PluginHost\\Plugins");
        if (!Directory.Exists(pluginDirectory))
        {
            Console.WriteLine("Plugins directory not found.");
            return;
        }

        foreach (string file in Directory.GetFiles(pluginDirectory, "*.dll"))
        {
            Assembly assembly = Assembly.LoadFile(Path.GetFullPath(file));
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }

                if (type.GetInterface(typeof(IPlugin).FullName!) == null)
                {
                    continue;
                }

                if (Activator.CreateInstance(type) is IPlugin plugin)
                {
                    Console.WriteLine($"\nLoaded: {plugin.Name}");
                    plugin.Execute();
                }
            }
        }
    }
}