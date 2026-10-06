namespace DebuggingDeadLock
{
    /// <summary>
    /// This is a simple console application that demonstrates a potential deadlock scenario when using async/await.
    /// </summary>
    public class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                await DeadlockMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static async Task DeadlockMethod()
        {
            var result = await SomeAsyncOperation();
            Console.WriteLine(result);
        }

        private static async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}