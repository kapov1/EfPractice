namespace EfPractice.OnlineStore.Entities;

public class Order
{
    private readonly List<OrderItem> _items = [];

    public Order(int customerId)
    {
        Validate(customerId);

        CustomerId = customerId;
    }

    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public DateTimeOffset? CreatedAt { get; private set; }
    public Customer? Customer { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public void AddItemOrThrow(OrderItem item)
    {
        if (Contains(item))
        {
            throw new InvalidOperationException("The order item has already been added.");
        }

        _items.Add(item);
    }

    public void RemoveItemOrThrow(OrderItem item)
    {
        if (!Contains(item))
        {
            throw new InvalidOperationException("The order item does not exist.");
        }

        _items.Remove(item);
    }

    private bool Contains(OrderItem item)
    {
        return _items.Any(i => (i.OrderId == item.OrderId) && (i.ProductId == item.ProductId));
    }

    private static void Validate(int customerId)
    {
        if (customerId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(customerId), 
                customerId,
                "The customer ID must be positive.");
        }
    }

    private Order() { }
}
