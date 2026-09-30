using System.Diagnostics;

namespace AsyncronousFileProcessor;

/// <summary>
/// Entry point executing asynchronous single-file benchmarks and multi-file concurrent pipelines.
/// </summary>
public class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Getting file Paths");
            string source1 = await GetFilePath();
            string source2 = await GetFilePath();
            string copy1 = await GetFilePath();
            string copy2 = await GetFilePath();

            if (source1.Equals(string.Empty) || source2.Equals(string.Empty) || copy1.Equals(string.Empty) || copy2.Equals(string.Empty))
            {
                Console.WriteLine("Invalid file path! ");
                return;
            }

            var writer1 = new FileWriter(source1);
            var writer2 = new FileWriter(source2);

            await Task.WhenAll(writer1.CreateLargeFileAsync(), writer2.CreateLargeFileAsync());
            Console.WriteLine("Files generated successfully.\nTime taken for single Asynchronous File ");
            var reader1 = new FileReader(source1);
            long fileStreamMs = await reader1.ReadWithFileStreamAsync();
            Console.WriteLine($"Async FileStream Read Time: {fileStreamMs} ms");
            long bufferedStreamMs = await reader1.ReadWithBufferedStreamAsync();
            Console.WriteLine($"Async BufferedStream Read Time: {bufferedStreamMs} ms\nProccessing multiple files concurrently");
            var reader2 = new FileReader(source2);
            Stopwatch concurrentWatch = Stopwatch.StartNew();
            Task<long> task1 = reader1.ProcessDataAsync(copy1);
            Task<long> task2 = reader2.ProcessDataAsync(copy2);
            long[] processingTimes = await Task.WhenAll(task1, task2);
            concurrentWatch.Stop();

            Console.WriteLine($"File 1 Core Execution Processing Time: {processingTimes[0]} ms\nFile 2 Core Execution Processing Time: {processingTimes[1]} ms" +
                $"\nTotal Shared Total Concurrent Time: {concurrentWatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    private static async Task<string> GetFilePath()
    {
        Console.Write("Enter your files path:");
        var filePath = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("Invalid file path!");
            return string.Empty;
        }

        filePath = filePath.Trim('"', ' ');
        if (File.Exists(filePath))
        {
            Console.WriteLine($"Success! File found at: {filePath}");
            return filePath;
        }
        else
        {
            Console.WriteLine("The specified file path does not exist. Creating the file");
        }

        return filePath;
    }
}
