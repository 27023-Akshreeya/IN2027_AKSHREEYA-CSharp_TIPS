namespace InventoryManager.Helper
{
    /// <summary>
    /// This class consists of methods that validates users inputs.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Determines whether the specified user choice is a single numeric character.
        /// </summary>
        /// <param name="userChoice">The input string representing the user's choice.</param>
        /// <returns>true if the choice is a single digit; otherwise, false.</returns>
        internal static bool IsChoiceValid(string userChoice)
        {
            if (string.IsNullOrEmpty(userChoice) || string.IsNullOrWhiteSpace(userChoice) || !userChoice.All(char.IsDigit) || userChoice.Length != 1)
            {
                return false;
            }
            else
            {
                try
                {
                    int.TryParse(userChoice, out int _);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// This method validates products name.
        /// </summary>
        /// <param name="productName">input product name as parameter.</param>
        /// <returns>returns true if valid and vise versa.</returns>
        internal static bool IsNameValid(string? productName)
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrWhiteSpace(productName) ||
                !productName.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This checks whether the input price is in valid format.
        /// </summary>
        /// <param name="price">input product price as parameter.</param>
        /// <returns>returns true if valid and vise versa.</returns>
        internal static bool IsPriceValid(string price)
        {
            if (string.IsNullOrEmpty(price) || string.IsNullOrWhiteSpace(price) || !price.All(char.IsDigit))
            {
                return false;
            }
            else
            {
                try
                {
                    decimal.TryParse(price, out decimal _);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// This checks whether the input product Id is in valid format.
        /// </summary>
        /// <param name="productId">input product ID as parameter.</param>
        /// <returns>returns true if valid and vise versa.</returns>
        internal static bool IsProductIdValid(string productId)
        {
            if (string.IsNullOrEmpty(productId) || productId.All(char.IsSymbol) || string.IsNullOrWhiteSpace(productId))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This checks whether the input product quantity is in valid format.
        /// </summary>
        /// <param name="productQuantity">input product quantity as parameter.</param>
        /// <returns>returns true if valid and vise versa.</returns>
        internal static bool IsQuantityValid(string productQuantity)
        {
            if (string.IsNullOrEmpty(productQuantity) || string.IsNullOrWhiteSpace(productQuantity) || !productQuantity.All(char.IsDigit))
            {
                return false;
            }
            else
            {
                try
                {
                    int.TryParse(productQuantity, out int _);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

                return true;
            }
        }
    }
}
