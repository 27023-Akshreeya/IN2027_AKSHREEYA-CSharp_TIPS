# Assingment 1 - Contact Manager
 
## Overview
 
This is a simple Contact Manager application developed using C#. It is a console-based application that allows users to store and manage contact information.
 
The project was created to practice object-oriented programming concepts, project structure, and basic CRUD (Create, Read, Update, Delete) operations.
 
## Features
 
- Add a new contact
- Search contacts by name
- View all contacts
- Edit existing contacts
- Remove contacts
- Input validation for user entries
- Contacts are displayed in alphabetical order
 
## Project Structure
 
```
ContactManager
│
├── View          // Handles user interaction
├── Models             // Contains data models and validation
├── Repository         // Stores contact data
├── Services           // Contains business logic
|── Helper
└── Program.cs         // Entry point
```

## Outcomes
 
- Object-Oriented Programming in C#
- Separating code into different layers
- Input validation
- Working with collections (`List<T>`)
- Writing cleaner and more maintainable code
- Using Git and GitHub for version control
 
## Future Improvements
 
Some improvements that can be added in the future include:
 
- Store contacts in a file or database
- Search using partial names
- Prevent duplicate contacts
- Improve the user interface
- Add unit tests

# Assignment 2 – C# OOP Console Applications
 
## Overview
 
This assignment contains three C# console applications developed to practice the fundamentals of Object-Oriented Programming (OOP). Each task focuses on applying concepts such as abstraction, inheritance, polymorphism, and input validation while following a simple layered project structure.
 
## Tasks
 
### Task 1 – Shape Hierarchy
A console application that calculates the area of different shapes such as Rectangle and Circle using inheritance and abstraction.
 
### Task 2 – Employee Hierarchy
A console application that calculates employee bonuses based on their role. It supports Manager and Developer employees using polymorphism.
 
### Task 3 – Banking System
A basic banking application that allows users to create savings or checking accounts and perform deposit and withdrawal operations with input validation.
 
## Project Structure
 
Each task follows a simple layered architecture:
 
- **ConsoleService** – Controls the application flow.
- **Model** – Contains classes and business logic.
- **View** – Handles user interaction.
- **Helper** – Performs input validation.
- **Repository** – Stores account data (used in the Banking System).
 
## Concepts Covered
 
- Classes and Objects
- Inheritance
- Abstraction
- Polymorphism
- Method Overriding
- Properties
- Input Validation
- Collections (`List<T>`)
- Basic Layered Architecture
 
## Technologies Used
 
- C#
- .NET Console Application
- Visual Studio
 
## Learning Outcome
 
This assignment provided hands-on experience in designing console applications using OOP principles, organizing code into multiple layers, validating user input, and building reusable and maintainable C# applications.