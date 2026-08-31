# Error Handling Tasks

## Overview
A C# console application that demonstrates exception handling through division and array access operations, including input validation and custom exceptions.

## Folder Structure

```text
ErrorHandlingTasks
├── Application
│   └── ExceptionService.cs
├── Domain
│   ├── InvalidUserInputException.cs
│   └── InvalidIndexAccessException.cs
├── Presentation
│   ├── ConsoleUI.cs
│   └── InputValidator.cs
└── Program.cs
```

## Components

### ExceptionService
Contains business logic methods:
- `PerformDivision()` - Performs division and handles divide-by-zero scenarios.
- `AccessArrayElement()` - Retrieves an array element using a specified index.

### ConsoleUI
Handles user interaction:
- `GetNumericInput()` - Validates numeric input.
- `Run()` - Executes all tasks.
- `ExecuteDivisionOperation()` - Demonstrates division exception handling.
- `ExecuteArrayAccessOperation()` - Demonstrates array access exception handling.
- `DisplayErrorMessage()` - Displays errors.
- `DisplayMessage()` - Displays informational messages.

### InputValidator
- `IsNumberValid()` - Verifies whether user input is a valid integer.

### Custom Exceptions
- `InvalidUserInputException` - Thrown for invalid user input.
- `InvalidIndexAccessException` - Represents invalid array index access.

### Program
- `Main()` - Application entry point.
- `HandleUnhandledException()` - Handles uncaught exceptions globally.

## Exception Handling

| Exception | Purpose |
|------------|---------|
| `DivideByZeroException` | Handles division by zero. |
| `IndexOutOfRangeException` | Handles invalid array index access. |
| `InvalidUserInputException` | Handles invalid numeric input. |
| `InvalidIndexAccessException` | Custom exception for invalid index access. |

## Concepts Covered

- Try-Catch-Finally
- Custom Exceptions
- Input Validation
- Exception Propagation
- Global Exception Handling
- Layered Architecture (Presentation, Application, Domain)