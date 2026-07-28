using InventoryManager.ConsoleService;
using InventoryManager.Model;

namespace InventoryManager.View
{
    /// <summary>
    /// 
    /// </summary>
    internal class UserConsole
    {
        /// <summary>
        /// 
        /// </summary>
        Service Service = new Service();

        /// <summary>
        /// 
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

                if (!Helper.Validator.IsChoiceValid(userChoice))
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

                        if (this.Service.AddNewProduct(newProductDetails))
                        {
                            Console.WriteLine(InventoryManagerResource.WrapperSuccess + " product added");
                        }

                        break;
                    case "2":
                        var allProducts = this.Service.ViewAllProducts();
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

                        var productDetails = this.Service.SearchByProductId(searchProductId);
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

                        if (this.Service.DoesProductExisits(deleteproductId))
                        {
                            if (this.Service.DeleteProductById(deleteproductId))
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

                        if (!this.Service.DoesProductExisits(editProductId))
                        {
                            Console.WriteLine(InventoryManagerResource.ProductNotFound);
                            continue;
                        }

                        Console.Write(InventoryManagerResource.EditOptions + "\n" + InventoryManagerResource.UserChoice + InventoryManagerResource.Editchoices);

                        string userEditChoice = Console.ReadLine() ?? string.Empty;

                        if (!Helper.Validator.IsChoiceValid(userEditChoice))
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
        /// 
        /// </summary>
        /// <param name="userEditChoice"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
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

                    return this.Service.UpdateProductByProductID(newProductName, productId, 1);
                case "2":
                    Console.Write(InventoryManagerResource.ProductID);
                    string newProductId = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsProductIdValid(newProductId))
                    {
                        return false;
                    }

                    if (this.Service.DoesProductExisits(newProductId))
                    {
                        Console.WriteLine(InventoryManagerResource.ProductExists);
                        return false;
                    }

                    return this.Service.UpdateProductByProductID(newProductId, productId, 2);
                case "3":
                    Console.Write(InventoryManagerResource.ProductPrice);
                    string newProductPrice = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsPriceValid(newProductPrice))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this.Service.UpdateProductByProductID(newProductPrice, productId, 3);
                case "4":
                    Console.Write(InventoryManagerResource.ProductQuantity);
                    string newProductQuantity = Console.ReadLine() ?? string.Empty;
                    if (!Helper.Validator.IsQuantityValid(newProductQuantity))
                    {
                        Console.WriteLine(InventoryManagerResource.InvalidInput);
                        return false;
                    }

                    return this.Service.UpdateProductByProductID(newProductQuantity, productId, 4);
                default:
                    Console.WriteLine(InventoryManagerResource.InvalidInput + " at default");
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productDetails"></param>
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
        /// 
        /// </summary>
        /// <returns></returns>
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

            if (this.Service.DoesProductExisits(productId))
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
