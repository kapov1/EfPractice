namespace EfPractice.Exercises.Configurations.FluentApi.ex2;

public class ProductEntity
{
    public ProductEntity(
        string sku, 
        string name, 
        decimal price, 
        string? description = null, 
        bool? isActive = null,
        int? stockQuantity = null)
    {
        ValidateArguments(
            price, 
            stockQuantity, 
            name,
            description,
            sku);

        Sku = sku;
        Name = name;
        Price = price;
        Description = description;
        IsActive = isActive;
        StockQuantity = stockQuantity;
    }

    public int Id { get; private set; }

    public string Sku { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public decimal Price { get; private set; }

    public int? StockQuantity { get; private set; }

    public bool? IsActive { get; private set; }

    public DateTimeOffset? CreatedAt { get; private set; }

    private static void ValidateArguments(
        decimal price, 
        int? stockQuantity, 
        string name, 
        string? description, 
        string sku)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(sku);

        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(
                "The price must not be negative.");
        }
        if (name.Length > 120)
        {
            throw new ArgumentOutOfRangeException(
                "The name must not be longer 120 characters.");
        }
        if (sku.Length > 32)
        {
            throw new ArgumentOutOfRangeException(
                "The sku must not be longer 32 characters.");
        }
        if (stockQuantity is < 0)
        {
            throw new ArgumentOutOfRangeException(
                "The stock quantity must not be negative.");
        }
        if (description is not null)
        {
            if (description.Length > 1000)
            {
                throw new ArgumentOutOfRangeException(
                    "The description must not be longer 1000 characters.");
            }
        }
    }

    private ProductEntity() { }
}