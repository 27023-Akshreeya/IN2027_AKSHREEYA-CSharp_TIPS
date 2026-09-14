using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingStacks.Application;

namespace UsingStacks.Presentation
{
    public class ConsoleUI
    {
        private IReversalService<char> _reversalService;

        public ConsoleUI(IReversalService<char> reversalService)
        {
            this._reversalService = reversalService;
        }

        public void Run()
        {
            Console.Write(StringReversalResource.Darshboard);
            string orignalString = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(orignalString))
            {
                Console.WriteLine("Invalid input! string cant be empty");
                return;
            }

            string reversedString = this._reversalService.Reverse(orignalString);
            Console.WriteLine($"The original string : {orignalString}\nThe reversed string : {reversedString}");
        }
    }
}
