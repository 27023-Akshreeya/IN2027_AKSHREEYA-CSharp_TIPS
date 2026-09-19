using System.IO;
using System.Text;

namespace Assignments;

/// <summary>
/// Handles writing operations.
/// </summary>
internal class FileWriter
{
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileWriter"/> class with a specified target file path.
    /// </summary>
    /// <param name="filename">The path of the file to be managed.</param>
    public FileWriter(string filename)
    {
        this._filePath = filename;
    }

    /// <summary>
    /// Generates a dummy file.
    /// </summary>
    /// <returns><see langword="true"/> if a new file was created; otherwise, <see langword="false"/>.</returns>
    public bool CreateLargeFile()
    {
        long content = 1024 * 1024 * 1024;
        var fileInfo = new FileInfo(this._filePath);
        long currentFileSize = fileInfo.Exists ? fileInfo.Length : 0;
        if (currentFileSize > content)
        {
            return false;
        }

        byte[] dummyLine = System.Text.Encoding.ASCII.GetBytes("Dummy Line\n");
        using (FileStream fs = new FileStream(this._filePath, FileMode.Create, FileAccess.Write))
        {
            while (currentFileSize < content)
            {
                fs.Write(dummyLine, 0, dummyLine.Length);
                currentFileSize += dummyLine.Length;
            }
        }

        return true;
    }

    /// <summary>
    /// Buffers a processed string before transferring it directly to the target file stream.
    /// </summary>
    /// <param name="destination">file stream where the data will be written.</param>
    /// <param name="processedString">The processed text data content to be saved.</param>
    internal void WriteToMemoryStream(FileStream destination, string processedString)
    {
        byte[] processedBytes = Encoding.UTF8.GetBytes(processedString);
        using var memoryStream = new MemoryStream();
        memoryStream.Write(processedBytes, 0, processedBytes.Length);
        memoryStream.Position = 0;
        memoryStream.WriteTo(destination);
    }
}