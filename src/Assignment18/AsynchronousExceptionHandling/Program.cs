namespace AsynchronousExceptionHandling;

/// <summary>
/// Entry point for the application demonstrating exception handling in asynchronous methods.
/// </summary>
internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            // MethodA(); // This will not catch the exception because MethodA returns void and exceptions thrown in async void methods are not propagated to the caller.
            await MethodB();
        }
        catch (SimulateException ex)
        {
            Console.WriteLine($"Caught exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught unexpected exception: {ex.Message}");
        }
    }

    private static async void MethodA()
    {
        await Task.Delay(1000);
        throw new SimulateException("Error from method that returns void");
    }

    private static async Task MethodB()
    {
        await Task.Delay(1000);
        throw new SimulateException("Error from method that returns Task");
    }
}