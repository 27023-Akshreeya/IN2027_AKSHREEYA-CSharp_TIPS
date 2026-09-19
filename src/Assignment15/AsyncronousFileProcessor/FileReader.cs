using System.Diagnostics;
using System.Text;

namespace AsyncronousFileProcessor
{
    /// <summary>
    /// Provides asynchronous methods to read and process data concurrently.
    /// </summary>
    public class FileReader
    {
        private const int BufferSize = 1024 * 64;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// Initializes the file reader with a source file path.
        /// </summary>
        /// <param name="filename">The source file path.</param>
        public FileReader(string filename)
        {
            this._filePath = filename;
        }

        /// <summary>
        /// Measures file read time using asynchronous FileStream.
        /// </summary>
        /// <returns>Elapsed milliseconds.</returns>
        public async Task<long> ReadWithFileStreamAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            byte[] buffer = new byte[BufferSize];
            using (FileStream fs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true))
            {
                while (await fs.ReadAsync(buffer, 0, buffer.Length) > 0)
                {
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures file read time using asynchronous BufferedStream.
        /// </summary>
        /// <returns>Elapsed milliseconds.</returns>
        public async Task<long> ReadWithBufferedStreamAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            byte[] buffer = new byte[BufferSize];
            using (FileStream fs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true))
            using (BufferedStream bs = new BufferedStream(fs, BufferSize))
            {
                while (await bs.ReadAsync(buffer, 0, buffer.Length) > 0)
                {
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Asynchronously converts text chunks to uppercase and writes them to a destination file.
        /// </summary>
        /// <param name="destinationPath">The output file path.</param>
        /// <returns>Elapsed milliseconds.</returns>
        public async Task<long> ProcessDataAsync(string destinationPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var writer = new FileWriter(destinationPath);
            byte[] readBuffer = new byte[BufferSize];
            using (FileStream sourceFs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true))
            using (FileStream destFs = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, BufferSize, useAsync: true))
            {
                int bytesRead;
                while ((bytesRead = await sourceFs.ReadAsync(readBuffer, 0, readBuffer.Length)) > 0)
                {
                    string processedString = Encoding.UTF8.GetString(readBuffer, 0, bytesRead).ToUpper();
                    await writer.WriteToMemoryStreamAsync(destFs, processedString);
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
