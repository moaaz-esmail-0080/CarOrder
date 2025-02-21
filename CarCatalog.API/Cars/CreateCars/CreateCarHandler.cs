
using MessageCore.CQRS;

namespace CarCatalog.API.Cars.CreateCars;

public record CreateCarCommand(
    string Name,
    List<string> Category,
    string Model,
    int Year,
    List<string> Features,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<CreateCarResult>;
public record CreateCarResult(Guid Id);

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        // التحقق من أن "Name" غير فارغ
        RuleFor(x => x.Name).NotEmpty().WithMessage("Model is required");
        // التحقق من أن "Category" غير فارغ
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");

        // التحقق من أن "Model" غير فارغ
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");

        // التحقق من أن "Year" هو سنة صحيحة (أكبر من 0)
        RuleFor(x => x.Year).GreaterThan(0).WithMessage("Year must be greater than 0");

        // التحقق من أن "Features" ليست فارغة
        RuleFor(x => x.Features).NotEmpty().WithMessage("Features are required");

        // التحقق من أن "Description" غير فارغ
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");

        // التحقق من أن "ImageFile" غير فارغ
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");

        // التحقق من أن "Price" أكبر من 0
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

    }
}

internal class CreateCarCommandHandler
    (IDocumentSession session)
    : ICommandHandler<CreateCarCommand, CreateCarResult>
{
    public async Task<CreateCarResult> Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
        //create Car entity from command object
        //save to database
        //return CreateCarResult result               

        var car = new Models.Cars
        {
            Name= command.Name,// اسم السيارة
            Category = command.Category,  // صنف السيارة
            Model = command.Model,  // موديل السيارة
            Year = command.Year,  // سنة الصنع
            Features = command.Features,  // ميزات السيارة
            Description = command.Description,  // وصف السيارة
            ImageFile = command.ImageFile,  // صورة السيارة
            Price = command.Price  // سعر السيارة
        };

        //save to database
        session.Store(car);
        await session.SaveChangesAsync(cancellationToken);

        //return result
        return new CreateCarResult(car.Id);
    }
}
