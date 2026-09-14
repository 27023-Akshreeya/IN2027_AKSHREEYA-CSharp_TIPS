using Task6.Application;

namespace Task6.Presentation;

internal class ConsoleUI
{
    private readonly NumberService _numberService;
    private readonly DictionaryService _dictionaryService;

    public ConsoleUI(NumberService numberService, DictionaryService dictionaryService)
    {
        this._numberService = numberService;
        this._dictionaryService = dictionaryService;
    }

    public void ExecuteIEnumerable()
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

    public void ExcecuteIReadOnly()
    {
        Console.WriteLine("Understanding IReadOnlyDictionary");
        var dictionary = this._dictionaryService.GenerateDictionary();
        Console.WriteLine("Dictionary:");
        this._dictionaryService.PrintDictionary(dictionary);
    }

    public void Run()
    {
        this.ExecuteIEnumerable();
        this.ExcecuteIReadOnly();
    }
}
