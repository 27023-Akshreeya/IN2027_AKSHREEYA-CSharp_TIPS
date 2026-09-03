// <copyright file="Validator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.Helper
{
    using InventoryManager.Model;

    /// <summary>
    /// This class consists of methods that validates users inputs.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Checks whether the specified input string is null, empty, or consists only of whitespace characters.
        /// </summary>
        /// <param name="input">Input string to check.</param>
        /// <returns>True if the input is valid, false otherwise.</returns>
        internal static bool IsInputValid(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified user choice is a single numeric character.
        /// </summary>
        /// <param name="userChoice">The input string representing the user's choice.</param>
        /// <returns>true if the choice is a single digit; otherwise, false.</returns>
        internal static bool IsUserChoiceValid(string userChoice)
        {
            if (!IsInputValid(userChoice) || userChoice.Length != 1 || !int.TryParse(userChoice, out int _))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method validates products name.
        /// </summary>
        /// <param name="productName">input product name as parameter.</param>
        /// <returns>returns true if valid and vice versa.</returns>
        internal static bool IsNameValid(string productName)
        {
            if (!IsInputValid(productName) || !productName.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This checks whether the input price is in valid format.
        /// </summary>
        /// <param name="price">input product price as parameter.</param>
        /// <returns>returns true if valid and vice versa.</returns>
        internal static bool IsPriceValid(string price)
        {
            if (!IsInputValid(price) || !decimal.TryParse(price, out decimal _))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This checks whether the input product Id is in valid format.
        /// </summary>
        /// <param name="productId">input product ID as parameter.</param>
        /// <returns>returns true if valid and vice versa.</returns>
        internal static bool IsProductIdValid(string productId)
        {
            if (!IsInputValid(productId) || productId.All(char.IsSymbol))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This checks whether the input product quantity is in valid format.
        /// </summary>
        /// <param name="productQuantity">input product quantity as parameter.</param>
        /// <returns>returns true if valid and vice versa.</returns>
        internal static bool IsQuantityValid(string productQuantity)
        {
            if (!IsInputValid(productQuantity) || !int.TryParse(productQuantity, out int _))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the specified product details.
        /// </summary>
        /// <param name="newProductDetails">The product details to validate.</param>
        /// <returns>true if the product details are valid; otherwise, false.</returns>
        internal static bool IsProductValid(Product newProductDetails)
        {
            if (newProductDetails.ProductId.Equals(string.Empty) || newProductDetails.ProductName.Equals(string.Empty)
                            || newProductDetails.Price.Equals(0) || newProductDetails.Quantity.Equals(0))
            {
                return false;
            }

            return true;
        }
    }
}
