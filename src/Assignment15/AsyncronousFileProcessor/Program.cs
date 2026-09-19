using System.Diagnostics;

namespace AsyncronousFileProcessor;

/// <summary>
/// Entry point executing asynchronous single-file benchmarks and multi-file concurrent pipelines.
/// </summary>
public class Program
{
    private const string Source1 = "Source1_file.txt";
    private const string Source2 = "Source2_file.txt";
    private const string Copy1 = "Copy1_file.txt";
    private const string Copy2 = "Copy2_file.txt";

    private static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Creating 2 files");
            var writer1 = new FileWriter(Source1);
            var writer2 = new FileWriter(Source2);

            await Task.WhenAll(writer1.CreateLargeFileAsync(), writer2.CreateLargeFileAsync());
            Console.WriteLine("Files generated successfully.\n");
            Console.WriteLine("Time taken for single Asynchronous File ");
            var reader1 = new FileReader(Source1);
            long fileStreamMs = await reader1.ReadWithFileStreamAsync();
            Console.WriteLine($"Async FileStream Read Time: {fileStreamMs} ms");
            long bufferedStreamMs = await reader1.ReadWithBufferedStreamAsync();
            Console.WriteLine($"Async BufferedStream Read Time: {bufferedStreamMs} ms");

            Console.WriteLine("\nProccessing multiple files concurrently");
            var reader2 = new FileReader(Source2);
            Stopwatch concurrentWatch = Stopwatch.StartNew();
            Task<long> task1 = reader1.ProcessDataAsync(Copy1);
            Task<long> task2 = reader2.ProcessDataAsync(Copy2);
            long[] processingTimes = await Task.WhenAll(task1, task2);
            concurrentWatch.Stop();

            Console.WriteLine($"File 1 Core Execution Processing Time: {processingTimes[0]} ms");
            Console.WriteLine($"File 2 Core Execution Processing Time: {processingTimes[1]} ms");
            Console.WriteLine($"Total Shared Total Concurrent Time: {concurrentWatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
