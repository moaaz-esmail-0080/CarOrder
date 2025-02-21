using CarBasket.API.Data;
using FluentValidation;
using MessageCore.CQRS;

namespace CarBasket.API.CarBasket.DeleteCarBasket;

public record DeleteCarBasketCommand(string UserName) : ICommand<DeleteCarBasketResult>;
public record DeleteCarBasketResult(bool IsSuccess);

public class DeleteCarBasketCommandValidator : AbstractValidator<DeleteCarBasketCommand>
{
    public DeleteCarBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class DeleteCarBasketCommandHandler(ICarBasketRepository repository)
    : ICommandHandler<DeleteCarBasketCommand, DeleteCarBasketResult>
{
    public async Task<DeleteCarBasketResult> Handle(DeleteCarBasketCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache       
        await repository.DeleteBasket(command.UserName, cancellationToken);

        return new DeleteCarBasketResult(true);
    }
}
