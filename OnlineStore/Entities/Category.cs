namespace EfPractice.OnlineStore.Entities;

public class Category
{
    private const int MaxNameLength = 100;

    private readonly List<Product> _products = [];

    public Category(string name)
    {
        Validate(name);

        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public IReadOnlyCollection<Product> Products =>_products.AsReadOnly();

    public void AddOrderOrThrow(Product product)
    {
        if (Contains(product))
        {
            throw new InvalidOperationException("The product has already been added.");
        }

        _products.Add(product);
    }

    public void RemoveOrderOrThrow(Product product)
    {
        if (!Contains(product))
        {
            throw new InvalidOperationException("This product does not exist.");
        }

        _products.Remove(product);
    }

    private bool Contains(Product product)
    {
        return _products.Any(p => p.Id == product.Id);
    }

    private static void Validate(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        if (name.Length > MaxNameLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(name), 
                name,
                $"Max length is {MaxNameLength} characters.");
        }
    }

    private Category() { }
}
