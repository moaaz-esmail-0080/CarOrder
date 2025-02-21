using CarBasket.API.Data;
using CarBasket.API.Models;
using FluentValidation;
using MessageCore.CQRS;

namespace CarBasket.API.CarBasket.StoreCarBasket;

public record StoreCarBasketCommand(ShoppingCart Cart) : ICommand<StoreCarBasketResult>;
public record StoreCarBasketResult(string UserName);

public class StoreCarBasketCommandValidator : AbstractValidator<StoreCarBasketCommand>
{
    public StoreCarBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class StoreCarBasketCommandHandler
    (ICarBasketRepository repository)
    : ICommandHandler<StoreCarBasketCommand, StoreCarBasketResult>
{
    public async Task<StoreCarBasketResult> Handle(StoreCarBasketCommand command, CancellationToken cancellationToken)
    {
        await DeductDiscount(command.Cart);

        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreCarBasketResult(command.Cart.UserName);
    }

    private Task DeductDiscount(ShoppingCart cart)
    {
        // Simulate discount deduction here (for example, applying a fixed amount of discount)
        foreach (var item in cart.Items)
        {
            // Example: Apply a fixed discount of $10 to each item
            item.Price -= 10; // Adjust this logic as per your requirements (can be percentage, etc.)
        }

        return Task.CompletedTask;
    }
}
