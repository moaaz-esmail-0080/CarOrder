namespace CarBasket.API.Models;

public class ShoppingCartItem
{
    public int Quantity { get; set; } = default!;
    public string Color { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public Guid CarId { get; set; } = default!;
    public string CarName { get; set; } = default!;
}
