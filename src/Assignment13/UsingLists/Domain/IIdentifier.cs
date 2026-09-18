namespace UsingLists.Domain;

/// <summary>
/// Defines a unique identifier wrapper for domain models.
/// </summary>
/// <typeparam name="TValue">The data type of the identifier.</typeparam>
public interface IIdentifier<TValue>
{
    /// <summary>
    /// Gets the unique identifier value.
    /// </summary>
    /// <value>The unique identifier value.</placeholder>
    /// </value>
    TValue Value { get; }
}
