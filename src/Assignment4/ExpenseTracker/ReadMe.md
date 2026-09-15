# Expense Tracker

A console-based Expense Tracker application built using **C#** and **Spectre.Console** to manage income and expense transactions while tracking the current net balance.

## Features

- Add Income and Expense transactions
- View transaction records
- Update existing transactions
- Delete transactions
- View net balance summary
- Input validation for amounts, dates, and user choices

## Project Structure

### Models
- `Income` - Stores income details.
- `Expense` - Stores expense details.
- `Transations` - Used for net balance event notifications.

### Helper
- `Validator`
  - `IsValidAmount()`
  - `IsValidDate()`
  - `IsChoiceValid()`
- `InputValidator` delegate for input validation.

### Repository
- `Repo`
  - Add, update, retrieve, and delete records.
  - Maintains `NetBalance`.
  - Raises `RunningNetBalance` events.

### Service
- `ExpenseTrackerService`
  - Handles business logic.
  - Communicates between UI and repository.

### UI
- `ExpenseTrackerViewer`
  - Displays menus and records.
  - Collects user input.
  - Handles add, update, delete, and summary operations.

## Menu Options

1. Add Transaction
2. View All Transactions
3. Transaction Summary
4. Edit Transaction
5. Delete Transaction
6. Exit

## Technologies Used

- C#
- .NET
- Spectre.Console
- Repository Pattern
- Delegates
- Events
- OOP Principles