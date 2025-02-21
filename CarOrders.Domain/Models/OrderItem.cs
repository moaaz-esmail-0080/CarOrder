using CarOrders.Domain.Abstractions;
using CarOrders.Domain.ValueObjects;

namespace CarOrders.Domain.Models;
public class OrderItem : Entity<OrderItemId>
{
    internal OrderItem(OrderId orderId, CarId carId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        CarId = carId;
        Quantity = quantity;
        Price = price;
    }

    public OrderId OrderId { get; private set; } = default!;
    public CarId CarId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
}
