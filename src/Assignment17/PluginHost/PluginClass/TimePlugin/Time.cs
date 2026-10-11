using PluginBase;
namespace TimePlugin;

public class Time : IPlugin
{
    public string Name => "Time Plugin";

    public void Execute()
    {
        Console.WriteLine($"Current time: {DateTime.Now}");
    }
}