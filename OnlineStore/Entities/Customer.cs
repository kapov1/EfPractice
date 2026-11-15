namespace EfPractice.OnlineStore.Entities;

public class Customer
{   
    private const int NameMaxLength = 100;

    public Customer(string name)
    {
        Validate(name);

        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private static void Validate(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        if (name.Length > NameMaxLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(name), 
                name,
                $"Maximun length is {NameMaxLength} characters.");
        }
    }

    private Customer() { }
}
