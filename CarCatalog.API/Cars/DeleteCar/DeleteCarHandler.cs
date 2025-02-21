using MessageCore.CQRS;

namespace CarCatalog.API.Cars.DeleteCar
{
    public record DeleteCarCommand(Guid Id) : ICommand<DeleteCarResult>;
    public record DeleteCarResult(bool IsSuccess);

    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Car ID is required");
        }
    }

    internal class DeleteCarCommandHandler
        (IDocumentSession session)
        : ICommandHandler<DeleteCarCommand, DeleteCarResult>
    {
        public async Task<DeleteCarResult> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
        {
            session.Delete<Models.Cars>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteCarResult(true);
        }
    }
}

