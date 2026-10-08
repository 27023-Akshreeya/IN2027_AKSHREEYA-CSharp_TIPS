using System;
using System.IO;

namespace FileDataProcessor;

/// <summary>
/// Entry point for the application that manages file creation, reading, and data processing operations.
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            string sourceFilePath = GetFilePath();
            if (sourceFilePath.Equals(string.Empty))
            {
                return;
            }

            Console.WriteLine("Creating a large file");
            var fileWriter = new FileWriter(sourceFilePath);
            if (fileWriter.CreateLargeFile())
            {
                Console.WriteLine("Dummy file generation completed successfully.\n");
            }
            else
            {
                Console.WriteLine("File exits and already contains a size more than 1GB");
            }

            var reader = new FileReader(sourceFilePath);
            string destinationFile = GetFilePath();
            if (destinationFile.Equals(string.Empty))
            {
                return;
            }

            Console.WriteLine($"FileStream Read Time: {reader.ReadWithFileStream()} ms\nBufferedStream Read Time: {reader.ReadWithBufferedStream()} ms" +
                $"\nTime taken to process data: {reader.ProcessData(destinationFile)}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static string GetFilePath()
    {
        Console.Write("Enter file path:");
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