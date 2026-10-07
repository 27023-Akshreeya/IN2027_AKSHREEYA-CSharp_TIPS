using System.Threading.Tasks;

namespace ApplicationOfConfigureAwait;

/// <summary>
/// Contains the application's entry point and demonstrates thread behavior differences when using ConfigureAwait in asynchronous methods.
/// </summary>
internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine($"Main thread ID : {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("\nThread behavior without Configure Await");
        await MethodBWithoutConfigureAwait();
        Console.WriteLine("\nThread behavior with Configure Await");
        await MethodBWithConfigureAwait();
    }

    private static async Task MethodBWithConfigureAwait()
    {
        Console.WriteLine($"Thread ID before Processing: {Thread.CurrentThread.ManagedThreadId}");
        int result = await MethodAWithConfigureAwait();
        Console.WriteLine($"Thread ID after Processing: {Thread.CurrentThread.ManagedThreadId}");
        result *= 2;
        Console.WriteLine($"Result after processing: {result}");
    }

    private static async Task MethodBWithoutConfigureAwait()
    {
        Console.WriteLine($"Thread ID before Processing: {Thread.CurrentThread.ManagedThreadId}");
        int result = await MethodAWithoutConfigureAwait();
        Console.WriteLine($"Thread ID after Processing: {Thread.CurrentThread.ManagedThreadId}");
        result *= 2;
        Console.WriteLine($"Result after processing: {result}");
    }

    private static async Task<int> MethodAWithConfigureAwait()
    {
        Console.WriteLine($"Thread ID before await: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(1000).ConfigureAwait(false);
        Console.WriteLine("Simulating process");
        int sum = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }
        });
        Console.WriteLine($"Thread ID after await: {Thread.CurrentThread.ManagedThreadId}");
        return sum;
    }

    private static async Task<int> MethodAWithoutConfigureAwait()
    {
        Console.WriteLine($"Thread ID before await: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(1000);
        Console.WriteLine("Simulating process");
        int sum = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }
        });
        Console.WriteLine($"Thread ID after await: {Thread.CurrentThread.ManagedThreadId}");
        return sum;
    }
}