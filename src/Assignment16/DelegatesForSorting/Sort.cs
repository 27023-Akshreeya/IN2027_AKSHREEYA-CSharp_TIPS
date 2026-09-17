namespace ProductSortService;

internal class Sort
{
    public delegate int SortDelegate(Product p1, Product p2);

    public int SortByName(Product p1, Product p2)
    {
        return string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase);
    }

    public int SortByCategory(Product p1, Product p2)
    {
        return string.Compare(p1.Category, p2.Category, StringComparison.OrdinalIgnoreCase);
    }

    public int SortByPrice(Product p1, Product p2)
    {
        return p1.Price.CompareTo(p2.Price);
    }
}
