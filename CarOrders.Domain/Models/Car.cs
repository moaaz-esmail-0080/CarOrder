using CarOrders.Domain.Abstractions;
using CarOrders.Domain.ValueObjects;

namespace CarOrders.Domain.Models;
public class Car : Entity<CarId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    public static Car Create(CarId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var car = new Car
        {
            Id = id,
            Name = name,
            Price = price
        };

        return car;
    }
}
