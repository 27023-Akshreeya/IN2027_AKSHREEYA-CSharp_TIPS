using System.Text;

namespace FileProcessOptimization
{
    /// <summary>
    /// Provides file write and read operations using a file stream.
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string path = "DummyFile.txt";
                string data = "This is some test data";
                byte[] writeBuffer = Encoding.ASCII.GetBytes(data);
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string textChunk = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.Write(textChunk);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}