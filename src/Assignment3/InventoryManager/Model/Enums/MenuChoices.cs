// <copyright file="MenuChoices.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace InventoryManager.Model.Enums
{
    /// <summary>
    /// This class consist of enum to represent menu choices.
    /// </summary>
    internal static class MenuChoices
    {
        /// <summary>
        /// To represent menu operation.
        /// </summary>
        internal enum MenuOperation : int
        {
            /// <summary>
            /// To add new product
            /// </summary>
            AddProduct = 1,

            /// <summary>
            /// To view all product
            /// </summary>
            ViewAllProduct = 2,

            /// <summary>
            /// To search all product
            /// </summary>
            SearchProduct = 3,

            /// <summary>
            /// To delete single product
            /// </summary>
            DeleteProduct = 4,

            /// <summary>
            /// To Edit single product
            /// </summary>
            EditProduct = 5,

            /// <summary>
            /// To exit appliction
            /// </summary>
            Exit = 6,
        }
    }
}
