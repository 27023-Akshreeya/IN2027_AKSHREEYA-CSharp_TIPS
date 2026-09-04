using System;
using ValueAndReferenceTypes.Application;
using ValueAndReferenceTypes.Presentation;

namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new ValueAndReferenceTypeService();
            var viewer = new ConsoleUI(service);
            viewer.Execute();
            Console.ReadKey();
        }
    }
}