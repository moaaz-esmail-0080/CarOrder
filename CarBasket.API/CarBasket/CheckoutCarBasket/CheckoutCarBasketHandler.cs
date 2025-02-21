
using CarBasket.API.Data;
using CarBasket.API.Dtos;
using FluentValidation;
using Mapster;
using MassTransit;
using MessageCore.CQRS;
using MessageCore.Messaging.Events;

namespace CarBasket.API.CarBasket.CheckoutCarBasket;

public record CheckoutCarBasketCommand(CarBasketCheckoutDto BasketCheckoutDto)
    : ICommand<CheckoutCarBasketResult>;
public record CheckoutCarBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator
    : AbstractValidator<CheckoutCarBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto can't be null");
        RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class CheckoutCarBasketCommandHandler
    (ICarBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutCarBasketCommand, CheckoutCarBasketResult>
{
    public async Task<CheckoutCarBasketResult> Handle(CheckoutCarBasketCommand command, CancellationToken cancellationToken)
    {
        // get existing basket with total price
        // Set totalprice on basketcheckout event message
        // send basket checkout event to rabbitmq using masstransit
        // delete the basket

        var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);
        if (basket == null)
        {
            return new CheckoutCarBasketResult(false);
        }

        var eventMessage = command.BasketCheckoutDto.Adapt<CarBasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutCarBasketResult(true);
    }
}
