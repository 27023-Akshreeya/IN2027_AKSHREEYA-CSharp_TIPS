using System;
using FileDataProcessor;

namespace Assignments;

/// <summary>
/// Entry point for the application that manages file creation, reading, and data processing operations.
/// </summary>
public class Program
{
    private const string SourceFilePath = "Source.txt";
    private const string DestinationFile = "Copy.txt";

    private static void Main(string[] args)
    {
        Console.WriteLine("Creating a large file");
        var fileWriter = new FileWriter(SourceFilePath);
        if (fileWriter.CreateLargeFile())
        {
            Console.WriteLine("Dummy file generation completed successfully.\n");
        }
        else
        {
            Console.WriteLine("File exits and already contains a size more than 1GB");
        }

        var reader = new FileReader(SourceFilePath);
        Console.WriteLine($"FileStream Read Time: {reader.ReadWithFileStream()} ms");
        Console.WriteLine($"BufferedStream Read Time: {reader.ReadWithBufferedStream()} ms");
        Console.WriteLine($"Time taken to process data: {reader.ProcessData(DestinationFile)}");
    }
}