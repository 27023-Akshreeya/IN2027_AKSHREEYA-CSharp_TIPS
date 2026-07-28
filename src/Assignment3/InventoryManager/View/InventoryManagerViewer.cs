namespace InventoryManager.View
{
    using InventoryManager.ConsoleService;
    using InventoryManager.Model;

    /// <summary>
    /// Handles user interaction, manages the console menu loop, and processes command-line inputs for the inventory system.
    /// </summary>
    internal class InventoryManagerViewer
    {
        /// <summary>
        /// The business logic service instance used to route inventory management actions.
        /// </summary>
        private Service service = new Service();

        /// <summary>
        /// Displays the main application interface loop, accepts user choices, and executes corresponding inventory workflows.
        /// </summary>
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(InventoryManagerResource.ConsoleName);
                Console.WriteLine(InventoryManagerResource.MenuDropDown);
                Console.Write(InventoryManagerResource.UserChoice + InventoryManagerResource.InputChoices);
                string userChoice = Console.ReadLine() ?? string.Empty;

                if (!Helper.Validator.IsUserChoiceValid(userChoice))
                {
                    Console.WriteLine(InventoryManagerResource.InvalidInput);
                    continue;
                }

                Console.WriteLine(InventoryManagerResource.emptyline);
                switch (userChoice)
                {
                    case "1":
                        var newProductDetails = this.GetNewProductDetails();

                        if (newProductDetails.productID.Equals(string.Empty) || newProductDetails.productName.Equals(string.Empty)
                            || newProductDetails.price.Equals(0) || newProductDetails.quantity.Equals(0))
                        {
                            Console.WriteLine(InventoryManagerResource.InvalidInput);
                            continue;
                        }

                        if (this.service.AddNewProduct(newProductDetails))
                        {
                            Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product added");
                        }

                        break;
                    case "2":
                        var allProducts = this.service.ViewAllProducts();
                        if (allProducts == null || allProducts.Count == 0)
                        {
                            Console.WriteLine(InventoryManagerResource.EmptyInventory);
                            continue;
                        }

                        this.DisplayProductsToUser(allProducts);
                        break;
                    case "3":
                        Console.Write(InventoryManagerResource.Search + "\n" + InventoryManagerResource.ProductID);
                        string searchProductId = Console.ReadLine() ?? string.Empty;
                        if (!Helper.Validator.IsProductIdValid(searchProductId))
                        {
                            Console.WriteLine(InventoryManagerResource.InvalidInput);
                            continue;
                        }

                        var productDetails = this.service.SearchByProductId(searchProductId);
                        if (productDetails == null)
                        {
                            Console.WriteLine(InventoryManagerResource.ProductNotFound);
                            continue;
                        }

                        this.DisplaySearchDetailsToUser(productDetails);
                        break;
                    case "4":
                        Console.Write(InventoryManagerResource.Delete + "\n" + InventoryManagerResource.ProductID);
                        string deleteproductId = Console.ReadLine() ?? string.Empty;
                        if (!Helper.Validator.IsProductIdValid(deleteproductId))
                        {
                            Console.WriteLine(InventoryManagerResource.InvalidInput);
                            continue;
                        }

                        if (this.service.DoesProductExisits(deleteproductId))
                        {
                            if (this.service.DeleteProductById(deleteproductId))
                            {
                                Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product deleted");
                            }
                        }
                        else
                        {
                            Console.WriteLine(InventoryManagerResource.ProductNotFound);
                            continue;
                        }

                        break;
                    case "5":
                        Console.Write(InventoryManagerResource.editInput + "\n" + InventoryManagerResource.ProductID);
                        var editProductId = Console.ReadLine() ?? string.Empty;
                        if (!Helper.Validator.IsProductIdValid(editProductId))
                        {
                            Console.WriteLine(InventoryManagerResource.InvalidInput);
                            continue;
                        }

                        if (!this.service.DoesProductExisits(editProductId))
                        {
                            Console.WriteLine(InventoryManagerResource.ProductNotFound);
                            continue;
                        }

                        Console.Write(InventoryManagerResource.EditOptions + "\n" + InventoryManagerResource.UserChoice + InventoryManagerResource.Editchoices);

                        string userEditChoice = Console.ReadLine() ?? string.Empty;

                        if (!Helper.Validator.IsUserChoiceValid(userEditChoice))
                        {
                            Console.WriteLine(InventoryManagerResource.InvalidInput + " at choice");
                            continue;
                        }

                        if (this.GetProductEditDetails(userEditChoice, editProductId))
                        {
                            Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product updated");
                        }
                        else
                        {
                            continue;
                        }

                        break;
                    case "6":
                        Console.WriteLine(InventoryManagerResource.Exiting);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        break;
                }
            }
        }

        /// <summary>
        /// Prompts the user for new property values based on their choice and updates the designated product.
        /// </summary>
        /// <param name="userEditChoice">The choice string indicating which property to modify (1 = Name, 2 = ID, 3 = Price, 4 = Quantity).</param>
        /// <param name="productId">The unique tracking identifier of the product targeted for modification.</param>
        /// <returns>True if the validation passes and the modification task executes successfully; otherwise, false.</returns>
        private bool GetProductEditDetails(string userEditChoice, string productId)
        {
            switch (userEditChoice)
            {
                case "1":
                    Console.Write(InventoryManagerResource.ProductName);
                    string newProductName = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsNameValid(newProductName))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this.service.UpdateProductByProductID(newProductName, productId, 1);
                case "2":
                    Console.Write(InventoryManagerResource.ProductID);
                    string newProductId = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsProductIdValid(newProductId))
                    {
                        return false;
                    }

                    if (this.service.DoesProductExisits(newProductId))
                    {
                        Console.WriteLine(InventoryManagerResource.ProductExists);
                        return false;
                    }

                    return this.service.UpdateProductByProductID(newProductId, productId, 2);
                case "3":
                    Console.Write(InventoryManagerResource.ProductPrice);
                    string newProductPrice = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsPriceValid(newProductPrice))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this.service.UpdateProductByProductID(newProductPrice, productId, 3);
                case "4":
                    Console.Write(InventoryManagerResource.ProductQuantity);
                    string newProductQuantity = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsQuantityValid(newProductQuantity))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this.service.UpdateProductByProductID(newProductQuantity, productId, 4);
                default:
                    Console.WriteLine(InventoryManagerResource.InvalidInput + " at default");
                    return false;
            }
        }

        /// <summary>
        /// Outputs the descriptive properties and total calculated inventory cost of a single matched search product.
        /// </summary>
        /// <param name="productDetails">The target product object instance containing data parameters to print.</param>
        private void DisplaySearchDetailsToUser(Product productDetails)
        {
            Console.WriteLine($"Product name : {productDetails.ProductName}\nProduct ID : {productDetails.ProductId}\nPrice : {productDetails.Price}\nQuantity : {productDetails.Quantity}\nTotal Cost : {productDetails.Price * productDetails.Quantity}");
        }

        private void DisplayProductsToUser(List<Product> allProducts)
        {
            foreach (var product in allProducts)
            {
                Console.WriteLine($"Product name : {product.ProductName}\nProduct ID : {product.ProductId}\nPrice : {product.Price}\nQuantity : {product.Quantity}\nTotal Cost : {product.Price * product.Quantity}");
                Console.WriteLine(InventoryManagerResource.emptyline);
            }
        }

        /// <summary>
        /// Iterates through a structured list collection of products and displays their details to the terminal interface.
        /// </summary>
        /// <param name="allProducts">A list configuration of target product entities to print out.</param>
        private (string productName, string productID, decimal price, int quantity) GetNewProductDetails()
        {
            Console.Write(InventoryManagerResource.ProductName);
            string productName = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsNameValid(productName))
            {
                return (string.Empty, string.Empty, 0, 0);
            }

            Console.Write(InventoryManagerResource.ProductID);
            string productId = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsProductIdValid(productId))
            {
                return (string.Empty, string.Empty, 0, 0);
            }

            if (this.service.DoesProductExisits(productId))
            {
                Console.WriteLine(InventoryManagerResource.ProductExists);
                return (string.Empty, string.Empty, 0, 0);
            }

            Console.Write(InventoryManagerResource.ProductPrice);
            string price = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsPriceValid(price))
            {
                return (string.Empty, string.Empty, 0, 0);
            }

            Console.Write(InventoryManagerResource.ProductQuantity);
            string productQuantity = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsQuantityValid(productQuantity))
            {
                return (string.Empty, string.Empty, 0, 0);
            }

            return (productName, productId, decimal.Parse(price), int.Parse(productQuantity));
        }
    }
}
