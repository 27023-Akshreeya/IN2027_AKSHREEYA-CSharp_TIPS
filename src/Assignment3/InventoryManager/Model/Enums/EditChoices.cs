// <copyright file="EditChoices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.Model.Enums
{
    /// <summary>
    /// Consist of enum representing edit choices.
    /// </summary>
    internal static class EditChoices
    {
        /// <summary>
        /// Specifies the edit operations that can be performed on a product.
        /// </summary>
        internal enum EditOperation
        {
            /// <summary>
            /// Represents the name of the product.
            /// </summary>
            ProductName = 1,

            /// <summary>
            /// Represents the Id of the product.
            /// </summary>
            ProductId = 2,

            /// <summary>
            /// Represents the Price of the product.
            /// </summary>
            Price = 3,

            /// <summary>
            /// Represents the quantity of the product.
            /// </summary>
            Quantity = 4,
        }
    }
}
