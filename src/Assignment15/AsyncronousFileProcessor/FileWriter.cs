using System.Text;

namespace AsyncronousFileProcessor
{
    /// <summary>
    /// Handles asynchronous writing operations and large file generation.
    /// </summary>
    public class FileWriter
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// Initializes the file writer with a target file path.
        /// </summary>
        /// <param name="filename">The target file path.</param>
        public FileWriter(string filename)
        {
            this._filePath = filename;
        }

        /// <summary>
        /// Asynchronously generates a 1 GB dummy file if it does not already exist.
        /// </summary>
        /// <returns>True if a new file was created; otherwise, false.</returns>
        public async Task<bool> CreateLargeFileAsync()
        {
            long content = 1024 * 1024 * 1024;
            var fileInfo = new FileInfo(this._filePath);
            long currentFileSize = fileInfo.Exists ? fileInfo.Length : 0;
            if (currentFileSize > content)
            {
                return false;
            }

            byte[] dummyLine = Encoding.ASCII.GetBytes("Dummy Line\n");
            using (FileStream fs = new FileStream(this._filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                while (currentFileSize < content)
                {
                    await fs.WriteAsync(dummyLine, 0, dummyLine.Length);
                    currentFileSize += dummyLine.Length;
                }
            }

            return true;
        }

        /// <summary>
        /// Asynchronously buffers a processed string in memory before writing to the target stream.
        /// </summary>
        /// <param name="destination">The destination file stream.</param>
        /// <param name="processedString">The text data to save.</param>
        /// <returns> A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        internal async Task WriteToMemoryStreamAsync(FileStream destination, string processedString)
        {
            byte[] processedBytes = Encoding.UTF8.GetBytes(processedString);
            using var memoryStream = new MemoryStream();
            await memoryStream.WriteAsync(processedBytes, 0, processedBytes.Length);
            memoryStream.Position = 0;
            await memoryStream.CopyToAsync(destination);
        }
    }
}
