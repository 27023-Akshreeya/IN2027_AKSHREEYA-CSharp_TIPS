# Inventory Manager

## Overview
This is a simple Inventory Manager application developed using C#. It is a console-based application that allows users to store and manage product stock information.

The project was created to practice object-oriented programming concepts, project structure, and basic CRUD (Create, Read, Update, Delete) operations.

## Features
* Add a new product
* View all products
* Search products by ID
* Remove products
* Edit existing products
* Input validation for user entries
* Products are displayed in alphabetical order
* Automatic calculation of total inventory cost for products

## Class & Method Architecture

### 1. Program (Entry Point)
* `Main(string[] args)`: The main entry execution method that initializes the console viewer and handles global exceptions to keep the app from crashing.

### 2.InventoryManagerViewer (View Layer)
* `Menu()`: Displays the main application interface loop, accepts user choices, and routes inputs to the correct workflow.
* `GetNewProductDetails()`: Captures and validates a complete set of fields from the console required to construct a new item record. Returns a named data tuple.
* `GetEditProductDetails(string userEditChoice, string productId)`: Prompts the user for new property values based on their choice (Name, ID, Price, or Quantity) and sends them to the service layer.
* `DisplaySingleProduct(Product productDetails)`: Outputs the properties and total calculated inventory cost (`Price * Quantity`) of a single matched search product.
* `DisplayAllProductsToUser(List<Product> allProducts)`: Iterates through the list collection of products and prints their details to the terminal.

### 3. Service (ConsoleService Layer)
* `DoesProductExist(string productId)`: Checks if a product with the specified ID already exists in the inventory tracking list.
* `AddNewProduct(tuple newProductDetails)`: Takes a tuple of data, builds a new `Product` instance, and sends it to the repository to be saved.
* `RemoveProduct(string deleteproductId)`: Finds a product by its ID and routes it to the repository for deletion.
* `SearchByProductId(string productId)`: Searches for a product by its unique identifier and returns the found item.
* `UpdateProductDetails(string newProductElement, string productId, int editChoice)`: Identifies which property to change based on the choice, updates the field safely with data parsing, and saves the updated product.
* `ViewAllProducts()`: Retrieves all products from the data store and sorts them alphabetically by their name using LINQ.

### 4. Repo (Repository Layer)
* `GetAllProducts()`: Retrieves the entire in-memory collection list of products.
* `AddProduct(Product newproduct)`: Appends a newly created product object into the data store list.
* `DeleteProduct(string productId)`: Removes a specific product from the data collection using its unique tracking identifier.
* `UpdateProduct(Product productToUpdate, string productId)`: Finds the matching product in the list and copies the updated values into it.

### 5. Product (Model Layer)
* `Product(productName, productID, price, quantity)`: Constructor that initializes a new instance of a product with its stock and pricing parameters.

---

## Project Structure
InventoryManager
│
├── View          // Handles user interaction ( InventoryManagerViewer)
├── Model         // Contains data models (Product)
├── Repository    // Stores product data (Repo)
├── ConsoleService// Contains business logic (Service)
├── Helper        // Contains validation utilities (Validator)
└── Program.cs    // Entry point


