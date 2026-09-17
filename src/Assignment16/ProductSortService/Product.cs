namespace ProductSortService;

internal class Product
{

    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    public Product(string name, string category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public override string ToString()
    {
        return $"[{Category,-12}] {Name,-15} | Price: ${Price:F2}";
    }
}
