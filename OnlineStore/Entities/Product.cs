namespace EfPractice.OnlineStore.Entities;

public class Product
{
    private const int NameMaxLength = 100;

    public Product(string name, int categoryId)
    {
        Validate(name, categoryId);

        Name = name;
        CategoryId = categoryId;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int CategoryId { get; private set; }
    public Category? Category { get; private set; }

    private static void Validate(string name, int categoryId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        if (name.Length > NameMaxLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(name), 
                name,
                $"Max length is {NameMaxLength} characters.");
        }

        if (categoryId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(categoryId), 
                categoryId,
                "The caterory ID must be positive.");
        }
    }

    private Product() { }
}
