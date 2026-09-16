namespace EventsAndDelegates
{
    /// <summary>
    /// j
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// lj
        /// </summary>
        /// <param name="args">l</param>
        public static void Main(string[] args)
        {
            var notifer = new Notifer();
            notifer.OnAction += PrintMessageToConsole;
            notifer.DisplayOnAction("Hello world");
            notifer.OnAction -= PrintMessageToConsole;
        }

        /// <summary>
        /// hj
        /// </summary>
        /// <param name="message">f</param>
        public static void PrintMessageToConsole(string message)
        {
            Console.WriteLine($"the recieved message is : {message}");
        }
    }
}