using System.Threading.Tasks;

namespace Assignments
{
    /// <summary>
    /// This is the enty point to the code
    /// </summary>
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                using HttpClient client = new HttpClient();
                string content = await client.GetStringAsync(@"https://www.geeksforgeeks.org/c-sharp/c-sharp-tutorial/");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}