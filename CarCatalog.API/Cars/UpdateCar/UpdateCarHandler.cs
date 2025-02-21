
using CarCatalog.API.Exceptions;
using MessageCore.CQRS;

namespace CarCatalog.API.Cars.UpdateCar;

public record UpdateCarCommand(Guid Id, string Name, List<string> Category, string Model, int Year, List<string> Features, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateCarResult>;
public record UpdateCarResult(bool IsSuccess);

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage("Car ID is required");

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

        RuleFor(command => command.Model)
      .Length(2, 150).WithMessage("Model must be greater than 0");

        RuleFor(command => command.Year)
      .GreaterThan(0).WithMessage("Year must be greater than 0");

        RuleFor(command => command.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

internal class UpdateCarCommandHandler
    (IDocumentSession session)
    : ICommandHandler<UpdateCarCommand, UpdateCarResult>
{
    public async Task<UpdateCarResult> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
    {
        var car = await session.LoadAsync<Models.Cars>(command.Id, cancellationToken);

        if (car is null)
        {
            throw new CarsNotFoundException(command.Id);
        }

        car.Name = command.Name;
        car.Category = command.Category;
        car.Description = command.Description;
        car.ImageFile = command.ImageFile;
        car.Price = command.Price;

        session.Update(car);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateCarResult(true);
    }
}
