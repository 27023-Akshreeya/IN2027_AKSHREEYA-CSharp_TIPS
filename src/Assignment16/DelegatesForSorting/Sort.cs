namespace DelegatesForSorting
{
    /// <summary>
    /// Encapsulates custom sorting comparison logic and delegate signatures for product sorting.
    /// </summary>
    internal class Sort
    {
        /// <summary>
        /// Defines a delegate structure for comparing two <see cref="Product"/> objects.
        /// </summary>
        /// <param name="p1">The first product to compare.</param>
        /// <param name="p2">The second product to compare.</param>
        /// <returns>A signed integer indicating their relative order.
        /// </returns>
        public delegate int SortDelegate(Product p1, Product p2);

        /// <summary>
        /// Compares two products by their names using a case-insensitive alphabetical comparison.
        /// </summary>
        /// <param name="p1">The first product to compare.</param>
        /// <param name="p2">The second product to compare.</param>
        /// <returns>A comparison value indicating alphabetical order.
        /// </returns>
        public int SortByName(Product p1, Product p2)
        {
            return string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compares two products by their categories using a case-insensitive alphabetical comparison.
        /// </summary>
        /// <param name="p1">The first product to compare.</param>
        /// <param name="p2">The second product to compare.</param>
        /// <returns>A comparison value indicating alphabetical order.
        /// </returns>
        public int SortByCategory(Product p1, Product p2)
        {
            return string.Compare(p1.Category, p2.Category, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compares two products numerically based on their prices.
        /// </summary>
        /// <param name="p1">The first product to compare.</param>
        /// <param name="p2">The second product to compare.</param>
        /// <returns> A comparison value indicating price order.<returns>
        public int SortByPrice(Product p1, Product p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }
    }
}
