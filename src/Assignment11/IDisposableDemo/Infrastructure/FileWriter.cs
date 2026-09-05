using System;
using System.IO;

namespace IDisposableDemo.Infrastructure
{
    /// <summary>
    /// Handles writing operations for files and manages resource disposal.
    /// </summary>
    public class FileWriter : IDisposable
    {
        /// <summary>
        /// Underlying stream writer instance.
        /// </summary>
        private readonly StreamWriter _streamWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filePath">The full path of the file to write to.</param>
        public FileWriter(string filePath)
        {
            this._streamWriter = new StreamWriter(filePath, true);
        }

        /// <summary>
        /// Writes a line of text to the file and flushes the stream.
        /// </summary>
        /// <param name="text">The string to write.</param>
        public void Write(string text)
        {
            this._streamWriter.WriteLine(text);
            this._streamWriter.Flush();
        }

        /// <summary>
        /// Releases all resources used by the stream writer.
        /// </summary>
        public void Dispose()
        {
            this._streamWriter.Dispose();
        }
    }
}
