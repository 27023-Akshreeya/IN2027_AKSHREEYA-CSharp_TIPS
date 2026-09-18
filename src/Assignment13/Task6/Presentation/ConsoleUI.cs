using System;
using System.Collections.Generic;
using Task6.Application;

namespace Task6.Presentation;

/// <summary>
/// Handles user interactions.
/// </summary>
internal class ConsoleUI
{
    private readonly NumberService _numberService;
    private readonly DictionaryService _dictionaryService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
    /// </summary>
    /// <param name="numberService">Number service.</param>
    /// <param name="dictionaryService">Dictionary service.</param>
    public ConsoleUI(NumberService numberService, DictionaryService dictionaryService)
    {
        this._numberService = numberService;
        this._dictionaryService = dictionaryService;
    }

    /// <summary>
    /// Runs the application workflow.
    /// </summary>
    public void Run()
    {
        this.ExecuteIEnumerable();
        this.ExcecuteIReadOnly();
    }

    /// <summary>
    /// Demonstrates IEnumerable operations.
    /// </summary>
    private void ExecuteIEnumerable()
    {
        Console.WriteLine("Understanding IEnumberable");
        List<int> numbersList = new () { 1, 2, 3, 4, 5 };

        int[] numbersArray = { 1, 2, 3, 4, 5 };

        Queue<int> numbersQueue = new ();

        numbersQueue.Enqueue(1);
        numbersQueue.Enqueue(2);
        numbersQueue.Enqueue(3);
        numbersQueue.Enqueue(4);
        numbersQueue.Enqueue(5);

        Console.WriteLine($"List Sum : {this._numberService.SumOfElements(numbersList)}");

        Console.WriteLine($"Array Sum : {this._numberService.SumOfElements(numbersArray)}");

        Console.WriteLine($"Queue Sum : {this._numberService.SumOfElements(numbersQueue)}");
    }

    /// <summary>
    /// Demonstrates IReadOnlyDictionary operations.
    /// </summary>
    private void ExcecuteIReadOnly()
    {
        Console.WriteLine("Understanding IReadOnlyDictionary");
        var dictionary = this._dictionaryService.GenerateDictionary();
        Console.WriteLine("Dictionary:");
        this.PrintDictionary(dictionary);
    }

    /// <summary>
    /// Displays dictionary contents.
    /// </summary>
    /// <param name="dictionary">Dictionary to display.</param>
    private void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        foreach (KeyValuePair<string, int> item in dictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
