namespace EfPractice.OnlineStore.Entities;

public class OrderItem
{
    public OrderItem(int orderId, int productId, int quantity)
    {
        Validate(orderId, productId, quantity);

        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Order Order { get; private set; } = null!;
    public Product Product { get; private set; } = null!;

    private static void Validate(int orderId, int productId, int quantity)
    {
        if (productId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(productId), 
                productId,
                "The product ID must be positive.");
        }
        
        if (orderId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(orderId), 
                orderId,
                "The order ID must be positive.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity), 
                quantity,
                "The quantity must be positive.");
        }
    }

    private OrderItem() { }
}
