using CarOrders.Domain.Exceptions;

namespace CarOrders.Domain.ValueObjects;
public record CarId
{
    public Guid Value { get; }
    private CarId(Guid value) => Value = value;
    public static CarId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("CarId cannot be empty.");
        }

        return new CarId(value);
    }
}
