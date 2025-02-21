
namespace CarCatalog.API.Cars.CreateCars;

public record CreateCarRequest(Guid Id, string Name, List<string> Category, string Model, int Year, List<string> Features, string Description, string ImageFile, decimal Price);


public record CreateCarResponse(Guid Id);

public class CreateCarEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/cars",
            async (CreateCarRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateCarCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateCarResponse>();

                return Results.Created($"/cars/{response.Id}", response);

            })
        .WithName("CreateCar")
        .Produces<CreateCarResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Car")
        .WithDescription("Create Car");
    }
}
