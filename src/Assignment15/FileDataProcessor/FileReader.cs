using System.Diagnostics;
using System.IO;
using System.Text;
using Assignments;

namespace FileDataProcessor;

/// <summary>
/// Handles file reading benchmarks.
/// </summary>
public class FileReader
{
    private const int BufferSize = 1024 * 64;
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileReader"/> class.
    /// Initializes the file reader with a source file path.
    /// </summary>
    /// <param name="filePath">The source file path.</param>
    public FileReader(string filePath)
    {
        this._filePath = filePath;
    }

    /// <summary>
    /// Measures file read time using FileStream.
    /// </summary>
    /// <returns>Elapsed milliseconds.</returns
    public long ReadWithFileStream()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        byte[] buffer = new byte[BufferSize];
        using (FileStream fs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            while (fs.Read(buffer, 0, buffer.Length) > 0)
            {
            }
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    /// <summary>
    /// Measures file read time using BufferedStream.
    /// </summary>
    /// <returns>Elapsed milliseconds.</returns>
    public long ReadWithBufferedStream()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        byte[] buffer = new byte[BufferSize];
        using (FileStream fs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (BufferedStream bs = new BufferedStream(fs, 1024 * 1024))
        {
            while (bs.Read(buffer, 0, buffer.Length) > 0)
            {
            }
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    /// <summary>
    /// Converts text chunks to uppercase and writes them to a destination file.
    /// </summary>
    /// <param name="destinationPath">The output file path.</param>
    /// <returns>Elapsed milliseconds.</returns>
    public long ProcessData(string destinationPath)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        byte[] readBuffer = new byte[BufferSize];

        using (FileStream sourceFs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
        using (FileStream destFs = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            int bytesRead;
            while ((bytesRead = sourceFs.Read(readBuffer, 0, readBuffer.Length)) > 0)
            {
                string processedString = Encoding.UTF8.GetString(readBuffer, 0, bytesRead).ToUpperInvariant();
                FileWriter.WriteToMemoryStream(destFs, processedString);
            }
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
