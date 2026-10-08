using System.Diagnostics;
using System.Text;

namespace FileProcessOptimization
{
    /// <summary>
    /// Provides file write and read operations using a file stream.
    /// </summary>
    public class Program
    {
        private const int BufferSize = 1024;

        private static void Main(string[] args)
        {
            string path = string.Empty;
            try
            {
                path = GetFilePath();
                string data = "This is dummy data";
                long timeBeforeFixing = TimeTakenBeforeFixing(path, data);
                Console.WriteLine($"Time taken before fixing: {timeBeforeFixing} ms");
                long timeAfterFixing = TimeTakenAfterFixing(path, data);
                Console.WriteLine($"Time taken after fixing: {timeAfterFixing} ms");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Failed to access file at \"{path}\"\nException: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Failed to access Directory\nException: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Failed to access file at \"{path}\"\nException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private static string GetFilePath()
        {
            Console.Write("Enter file path:");
            var filePath = Console.ReadLine() ?? string.Empty;
            filePath = filePath.Trim('"', ' ');
            if (File.Exists(filePath))
            {
                Console.WriteLine($"Success! File found at: {filePath}");
                return filePath;
            }

            Console.WriteLine("The specified file path does not exist. Creating the file");
            return filePath;
        }

        private static long TimeTakenBeforeFixing(string path, string data)
        {
            var watch = Stopwatch.StartNew();

            // Writing to file using MemoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                // Write from MemoryStream to file
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            // Reading from file using FileStream
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[BufferSize];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Simulate memory inefficiency
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]);
                    }

                    Console.WriteLine();
                }
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        private static long TimeTakenAfterFixing(string path, string data)
        {
            var watch = Stopwatch.StartNew();

            // Writing to file using FileStream directly
            byte[] writeBuffer = Encoding.ASCII.GetBytes(data);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                fileStream.Write(writeBuffer, 0, writeBuffer.Length);
            }

            // Reading from file using FileStream directly
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[BufferSize];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string textChunk = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.Write(textChunk);
                }
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}