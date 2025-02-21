using MessageCore.Exceptions;

namespace CarBasket.API.Exceptions;

public class CarBasketNotFoundException : NotFoundException
{
    public CarBasketNotFoundException(string userName) : base("CarBasket", userName)
    {

    }
}
