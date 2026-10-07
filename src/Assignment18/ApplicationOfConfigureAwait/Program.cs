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
        await MethodBWithoutAwait();
        Console.WriteLine("\nThread behavior with Configure Await");
        await MethodBWithAwait();
    }

    private static async Task MethodBWithAwait()
    {
        Console.WriteLine($"Thread ID before Processing: {Thread.CurrentThread.ManagedThreadId}");
        int result = await MethodAWithAwait();
        await Task.Run(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                result += i;
            }
        });
        Console.WriteLine($"Thread ID after Processing: {Thread.CurrentThread.ManagedThreadId}");
    }

    private static async Task MethodBWithoutAwait()
    {
        Console.WriteLine($"Thread ID before Processing: {Thread.CurrentThread.ManagedThreadId}");
        int result = await MethodAWithoutAwait();
        await Task.Run(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                result += i;
            }
        });
        Console.WriteLine($"Thread ID after Processing: {Thread.CurrentThread.ManagedThreadId}");
    }

    private static async Task<int> MethodAWithAwait()
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

    private static async Task<int> MethodAWithoutAwait()
    {
        Console.WriteLine($"Thread ID before await: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(1000);
        Console.WriteLine("Simulating process");
        int sum = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 100000000; i++)
            {
                sum += i;
            }
        });
        Console.WriteLine($"Thread ID after await: {Thread.CurrentThread.ManagedThreadId}");
        return sum;
    }
}