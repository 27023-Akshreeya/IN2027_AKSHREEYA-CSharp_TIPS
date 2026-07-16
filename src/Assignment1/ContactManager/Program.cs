using ContactManager.ConsoleView;
using ContactManager.Service;

namespace ContactManager
{
    /// <summary>
    /// program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main scope
        /// </summary>
        /// <param name="args">argumenrs</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                UserConsole userConsole = new UserConsole();

                userConsole.Menu();

                string input = userConsole.GetChoice();
                char character;
                if (input == null)
                {
                    character = char.Parse(input);
                }
                else
                {
                    char.TryParse(input, out character);
                }
                switch (character)
                {
                    case 'A' or 'a':
                        userConsole.GetAdd();
                        break;
                    case 'S' or 's':
                        userConsole.GetSearch();
                        Console.WriteLine();
                        break;
                    case 'V' or 'v':
                        userConsole.GetView();
                        Console.WriteLine();
                        break;
                    case 'E' or 'e':
                        userConsole.GetEdit();
                        Console.WriteLine();
                        break;
                    case 'R' or 'r':
                        userConsole.GetRemove();
                        Console.WriteLine();
                        break;
                    case 'C' or 'c':
                        flag = false;
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}