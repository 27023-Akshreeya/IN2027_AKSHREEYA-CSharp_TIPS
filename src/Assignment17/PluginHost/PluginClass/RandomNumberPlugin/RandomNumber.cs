using PluginBase;
namespace RandomNumberPlugin;

public class RandomNumber : IPlugin
{
    public string Name => "Random Number Plugin";

    public void Execute()
    {
        Random random = new Random();
        int number = random.Next(1, 101);

        Console.WriteLine($"Random number: {number}");
    }
}
