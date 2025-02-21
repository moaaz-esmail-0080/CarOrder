namespace CarOrders.Application.Dtos;

public record OrderItemDto(Guid OrderId, Guid CarId, int Quantity, decimal Price);
