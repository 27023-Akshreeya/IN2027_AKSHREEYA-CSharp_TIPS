using System.Text.Json;

namespace AsyncAwaitOperation;

/// <summary>
/// Provides the entry point and core asynchronous operations for the application.
/// </summary>
internal class Program
{
    private static async Task Main(string[] args)
    {
        int result = await MethodC();
        Console.WriteLine($"The count key-value pair : {result}");
    }

    private static async Task<int> MethodA()
    {
        int sum = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 100000000; i++)
            {
                sum += i;
            }
        });
        return sum;
    }

    private static async Task<string> MethodB()
    {
        int result = await MethodA();
        HttpClient client = new HttpClient();
        return await client.GetStringAsync($"https://httpbin.org/get?value={result}");
    }

    private static async Task<int> MethodC()
    {
        string response = await MethodB();
        return JsonSerializer.Deserialize<Dictionary<string, object>>(response)?.Count ?? 0;
    }
}