namespace EfPractice.OnlineStore.Entities;

public class Category
{
    private const int MaxNameLength = 100;

    public Category(string name)
    {
        Validate(name);

        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

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
