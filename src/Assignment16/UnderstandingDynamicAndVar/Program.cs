namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var value = "Hello World!";
            Console.WriteLine($"Understanding var keyword\nValue before reassigning : {value}" +
                    $"\nType before reassigning : {value.GetType()}");

            // value = 123; //this throws an compile time exception
            // This is because var locks the data type of the variable
            // to the real data type behind the scenes, hence cant be changed
            dynamic dynamicValue = 12345;
            Console.WriteLine($"Understanding dynamic keyword\nValue before reassigning : {dynamicValue}" +
                    $"\nType before reassigning : {dynamicValue?.GetType()}");
            dynamicValue = "lorem ipsum";
            Console.WriteLine($"Value after reassigning : {dynamicValue}" +
                    $"\nType after reassigning : {dynamicValue?.GetType()}");
        }
    }
}