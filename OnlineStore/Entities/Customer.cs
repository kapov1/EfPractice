namespace EfPractice.OnlineStore.Entities;

public class Customer
{   
    private const int NameMaxLength = 100;

    private readonly List<Order> _orders = [];

    public Customer(string name)
    {
        Validate(name);

        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    public void AddOrderOrThrow(Order order)
    {
        if (Contains(order))
        {
            throw new InvalidOperationException("The order has already been added.");
        }

        _orders.Add(order);
    }

    public void RemoveOrderOrThrow(Order order)
    {
        if (!Contains(order))
        {
            throw new InvalidOperationException("This order does not exist.");
        }

        _orders.Remove(order);
    }

    private bool Contains(Order order)
    {
        return _orders.Any(o => o.Id == order.Id);
    }

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
