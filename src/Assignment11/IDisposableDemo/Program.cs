using IDisposableDemo.Infrastructure;

namespace Assignments
{
    /// <summary>
    /// Application entry point demonstrating the IDisposable pattern with files.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Executes file write and read operations using managed resources.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                const string filepath = "file.txt";
                Console.WriteLine("Writing to file");
                using (var writer = new FileWriter(filepath))
                {
                    writer.Write("Hello world!");
                    writer.Write("this is a new line");
                }

                Console.WriteLine("Read file");

                using (var reader = new FileReader(filepath))
                {
                    var fileContent = reader.ReadFile();
                    Console.WriteLine(fileContent);
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
