using UsingQueues.Application;
using UsingQueues.Domain;

namespace UsingQueues.Presentation;

/// <summary>
/// Handles user interactions for queue management.
/// </summary>
public class ConsoleUI
{
    private readonly IQueueService _queueService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
    /// </summary>
    /// <param name="queueService">Queue service.</param>
    public ConsoleUI(IQueueService queueService)
    {
        this._queueService = queueService;
    }

    /// <summary>
    /// Runs the queue operations workflow.
    /// </summary>
    public void Run()
    {
        this.AddNewNames();
        this.DisplayCurrentQueue();
        this.RemoveName();
        this.DisplayCurrentQueue();
    }

    /// <summary>
    /// Removes the first person from the queue.
    /// </summary>
    private void RemoveName()
    {
        Console.WriteLine("Remove first person from the queue");
        var removedPerson = this._queueService.RemoveFirstPerson();
        Console.WriteLine($"{removedPerson.Name} removed successfull");
    }

    /// <summary>
    /// Displays all people in the queue.
    /// </summary>
    private void DisplayCurrentQueue()
    {
        int personCount = 0;
        var queue = this._queueService.GetAllPersons();
        foreach (var person in queue)
        {
            Console.WriteLine($"{personCount + 1}. {person.Name}");
            personCount++;
        }
    }

    /// <summary>
    /// Adds new people to the queue.
    /// </summary>
    private void AddNewNames()
    {
        Console.WriteLine("Enter 5 Names of people you want to add");
        for (int person = 0; person < 5; person++)
        {
            string name = this.GetInputWithAttempts($"Enter name of person {person + 1}: ", InputValidation.IsNameValid, "Invalid name! name cant be empty");
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"Couldn't add person {name}!" +
                    $"Enter a valid name");
                continue;
            }

            if (this._queueService.AddNewPerson(new Person(name)))
            {
                Console.WriteLine("Name added successfully");
            }
        }
    }

    /// <summary>
    /// Gets validated input from the user.
    /// </summary>
    /// <param name="input">Input prompt.</param>
    /// <param name="validator">Input validator.</param>
    /// <param name="invalidInput">Invalid input message.</param>
    /// <returns>The validated input.</returns>
    private string GetInputWithAttempts(string input, InputValidator validator, string invalidInput)
    {
        for (int tries = 3; tries > 0; tries--)
        {
            Console.Write($"\nAttempts remaining: {tries}\n{input}");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (validator(userInput))
            {
                return userInput;
            }

            Console.WriteLine(invalidInput);
        }

        return string.Empty;
    }
}
