namespace CarCatalog.API.Cars.UpdateCar;

public record UpdateCarRequest(Guid Id, string Name, List<string> Category, string Model, int Year, List<string> Features, string Description, string ImageFile, decimal Price);
public record UpdateCarResponse(bool IsSuccess);

public class UpdateCarEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/cars",
            async (UpdateCarRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateCarCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateCarResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateCar")
            .Produces<UpdateCarResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Car")
            .WithDescription("Update Car");
    }
}
