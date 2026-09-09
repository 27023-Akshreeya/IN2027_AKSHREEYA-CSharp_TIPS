namespace LINQchallenges.Domain
{
    /// <summary>
    /// Represents a supplier entity in the domain model.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the unique identifier for the supplier.
        /// </summary>
        /// <value>
        /// The unique identifier for the supplier.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the supplied product.
        /// </summary>
        /// <value>
        /// The unique identifier of the supplied product.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Returns a comma-separated string representation of the supplier details.
        /// </summary>
        /// <returns>A string containing the supplier ID, name, and associated product ID.</returns>
        public override string ToString()
        {
            return $"{this.SupplierId}, {this.SupplierName}, {this.ProductId}";
        }
    }
}
