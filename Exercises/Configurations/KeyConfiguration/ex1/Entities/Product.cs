namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;

public class Product
{
    public Product(
        string sku, 
        string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sku);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Sku = sku;
        Name = name;
    }

    public int Id { get; private set; }

    public string Sku { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    private Product() { } 
}
