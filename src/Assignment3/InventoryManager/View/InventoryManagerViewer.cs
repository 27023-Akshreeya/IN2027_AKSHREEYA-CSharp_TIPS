// <copyright file="InventoryManagerViewer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.View
{
    using InventoryManager.ConsoleService;
    using InventoryManager.Helper;
    using InventoryManager.Model;
    using InventoryManager.Model.Enums;

    /// <summary>
    /// Handles user interaction, manages the console menu loop, and processes command-line inputs for the inventory system.
    /// </summary>
    public class InventoryManagerViewer
    {
        private readonly Service _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManagerViewer"/> class.
        /// </summary>
        /// <param name="service">
        /// Service instance used to execute inventory management operations.
        /// </param>
        public InventoryManagerViewer(Service service)
        {
            this._service = service;
        }

        /// <summary>
        /// Displays an error message to the console, typically used for validation or operation failures.
        /// </summary>
        /// <param name="message">the error message.</param>
        public static void ErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays the main application interface loop, accepts user choices, and executes corresponding inventory workflows.
        /// </summary>
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(InventoryManagerResource.ConsoleName + InventoryManagerResource.MenuDropDown);
                Console.Write(InventoryManagerResource.UserChoice + InventoryManagerResource.InputChoices);
                string userChoice = Console.ReadLine() ?? string.Empty;

                if (!Validator.IsUserChoiceValid(userChoice))
                {
                    Console.WriteLine(InventoryManagerResource.InvalidInput);
                    continue;
                }

                Console.WriteLine();
                switch ((MenuChoices)int.Parse(userChoice))
                {
                    case MenuChoices.AddProduct:
                        var newProductDetails = this.GetNewProductDetails();
                        if (newProductDetails is null)
                        {
                            Console.WriteLine(InventoryManagerResource.InvalidInput);
                            continue;
                        }

                        if (this._service.AddNewProduct(newProductDetails))
                        {
                            Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product added");
                            break;
                        }

                        Console.WriteLine(InventoryManagerResource.ErrorMessage);

                        break;
                    case MenuChoices.ViewAllProducts:
                        if (!this._service.HasProducts())
                        {
                            Console.WriteLine(InventoryManagerResource.EmptyInventory);
                            continue;
                        }

                        var allProducts = this._service.ViewAllProducts();
                        this.DisplayAllProductsToUser(allProducts);
                        break;
                    case MenuChoices.SearchProduct:
                        if (!this._service.HasProducts())
                        {
                            Console.WriteLine(InventoryManagerResource.EmptyInventory);
                            continue;
                        }

                        this.SearchProduct();
                        break;
                    case MenuChoices.DeleteProduct:
                        if (!this._service.HasProducts())
                        {
                            Console.WriteLine(InventoryManagerResource.EmptyInventory);
                            continue;
                        }

                        this.GetDeleteProductDetails();
                        break;
                    case MenuChoices.EditProduct:
                        if (!this._service.HasProducts())
                        {
                            Console.WriteLine(InventoryManagerResource.EmptyInventory);
                            continue;
                        }

                        this.EditProduct();
                        break;
                    case MenuChoices.Exit:
                        Console.WriteLine(InventoryManagerResource.Exiting);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        break;
                }
            }
        }

        private void SearchProduct()
        {
            Console.Write(InventoryManagerResource.Search + "\n" + InventoryManagerResource.ProductID);
            string searchProductId = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsProductIdValid(searchProductId) || !this._service.DoesProductExist(searchProductId))
            {
                Console.WriteLine(InventoryManagerResource.InvalidInput);
                return;
            }

            var productDetails = this._service.SearchByProductId(searchProductId);
            if (!(productDetails is null))
            {
                this.DisplaySingleProduct(productDetails);
                return;
            }
        }

        private void GetDeleteProductDetails()
        {
            Console.Write(InventoryManagerResource.Delete + "\n" + InventoryManagerResource.ProductID);
            string deleteproductId = Console.ReadLine() ?? string.Empty;
            if (Validator.IsProductIdValid(deleteproductId) && this._service.DoesProductExist(deleteproductId))
            {
                this._service.RemoveProduct(deleteproductId);
                Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product deleted");
                return;
            }

            Console.WriteLine(InventoryManagerResource.ProductNotFound);
        }

        private void EditProduct()
        {
            Console.Write(InventoryManagerResource.editInput + "\n" + InventoryManagerResource.ProductID);
            var editProductId = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsProductIdValid(editProductId) || !this._service.DoesProductExist(editProductId))
            {
                Console.WriteLine(InventoryManagerResource.InvalidInput);
                return;
            }

            Console.Write(InventoryManagerResource.EditOptions + "\n" + InventoryManagerResource.UserChoice + InventoryManagerResource.Editchoices);
            string userEditChoice = Console.ReadLine() ?? string.Empty;
            if (Validator.IsUserChoiceValid(userEditChoice) && this.GetEditProductDetails(int.Parse(userEditChoice), editProductId))
            {
                Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product updated");
                return;
            }

            Console.WriteLine(InventoryManagerResource.InvalidInput);
        }

        /// <summary>
        /// Prompts the user for new property values based on their choice and updates the designated product.
        /// </summary>
        /// <param name="userEditChoice">The choice int indicating which property to modify (1 = Name, 2 = ID, 3 = Price, 4 = Quantity).</param>
        /// <param name="productId">The unique tracking identifier of the product targeted for modification.</param>
        /// <returns>True if the validation passes and the modification task executes successfully; otherwise, false.</returns>
        private bool GetEditProductDetails(int userEditChoice, string productId)
        {
            switch ((EditChoices)userEditChoice)
            {
                case EditChoices.ProductName:
                    Console.Write(InventoryManagerResource.ProductName);
                    string newProductName = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsNameValid(newProductName))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this._service.UpdateProductName(productId, newProductName);
                case EditChoices.ProductId:
                    Console.Write(InventoryManagerResource.ProductID);
                    string newProductId = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsProductIdValid(newProductId))
                    {
                        return false;
                    }

                    if (this._service.DoesProductExist(newProductId))
                    {
                        Console.WriteLine(InventoryManagerResource.ProductExists);
                        return false;
                    }

                    return this._service.UpdateProductId(productId, newProductId);
                case EditChoices.Price:
                    Console.Write(InventoryManagerResource.ProductPrice);
                    string newProductPrice = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsPriceValid(newProductPrice))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this._service.UpdateProductPrice(productId, decimal.Parse(newProductPrice));
                case EditChoices.Quantity:
                    Console.Write(InventoryManagerResource.ProductQuantity);
                    string newProductQuantity = Console.ReadLine() ?? string.Empty;
                    if (!Validator.IsQuantityValid(newProductQuantity))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this._service.UpdateProductQuantity(productId, int.Parse(newProductQuantity));
                default:
                    Console.WriteLine(InventoryManagerResource.InvalidInput + " at default");
                    return false;
            }
        }

        /// <summary>
        /// Outputs the descriptive properties and total calculated inventory cost of a single matched search product.
        /// </summary>
        /// <param name="productDetails">The target product object instance containing data parameters to print.</param>
        private void DisplaySingleProduct(Product productDetails)
        {
            Console.WriteLine($"Product name : {productDetails.ProductName}\nProduct ID : {productDetails.ProductId}" +
                    $"\nPrice : {productDetails.Price}\nQuantity : {productDetails.Quantity}" +
                    $"\nTotal Cost : {productDetails.Price * productDetails.Quantity}");
        }

        private void DisplayAllProductsToUser(List<Product> allProducts)
        {
            foreach (var product in allProducts)
            {
                this.DisplaySingleProduct(product);
            }
        }

        /// <summary>
        /// This method gets new product details.
        /// </summary>
        private Product? GetNewProductDetails()
        {
            Console.Write(InventoryManagerResource.ProductName);
            string productName = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsNameValid(productName))
            {
                return null;
            }

            Console.Write(InventoryManagerResource.ProductID);
            string productId = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsProductIdValid(productId))
            {
                return null;
            }

            if (this._service.DoesProductExist(productId))
            {
                Console.WriteLine(InventoryManagerResource.ProductExists);
                return null;
            }

            Console.Write(InventoryManagerResource.ProductPrice);
            string price = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsPriceValid(price))
            {
                return null;
            }

            Console.Write(InventoryManagerResource.ProductQuantity);
            string productQuantity = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsQuantityValid(productQuantity))
            {
                return null;
            }

            return new Product(productName, productId, Convert.ToDecimal(price), Convert.ToInt32(productQuantity));
        }
    }
}
