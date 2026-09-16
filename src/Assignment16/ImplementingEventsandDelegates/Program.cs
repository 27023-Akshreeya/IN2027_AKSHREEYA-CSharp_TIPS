namespace ImplementingEventsandDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var notifer = new Notifer();
            notifer.OnAction += PrintMessageToConsole;
            notifer.DisplayOnAction("Hello world");
            notifer.OnAction -= PrintMessageToConsole;
        }

        static void PrintMessageToConsole(string message)
        {
            Console.WriteLine($"the recieved message is : {message}");
        }
    }
}
