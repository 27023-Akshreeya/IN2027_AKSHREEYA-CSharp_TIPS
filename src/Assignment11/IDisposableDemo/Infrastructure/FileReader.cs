using System;
using System.IO;

namespace IDisposableDemo.Infrastructure
{
    /// <summary>
    /// Handles reading operations for files and manages resource disposal.
    /// </summary>
    public class FileReader : IDisposable
    {
        /// <summary>
        /// Underlying stream reader instance.
        /// </summary>
        private readonly StreamReader _streamReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filePath">The full path of the file to read.</param>
        public FileReader(string filePath)
        {
            this._streamReader = new StreamReader(filePath);
        }

        /// <summary>
        /// Reads the entire file content.
        /// </summary>
        /// <returns>The file contents as a string, or null.</returns>
        public string? ReadFile()
        {
            return this._streamReader.ReadToEnd();
        }

        /// <summary>
        /// Releases all resources used by the stream reader.
        /// </summary>
        public void Dispose()
        {
            this._streamReader.Dispose();
        }
    }
}
