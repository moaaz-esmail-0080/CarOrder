
namespace CarCatalog.API.Cars.DeleteCar;

//public record DeleteCarRequest(Guid Id);
public record DeleteCarResponse(bool IsSuccess);

public class DeleteCarEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cars/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteCarCommand(id));

            var response = result.Adapt<DeleteCarResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteCar")
        .Produces<DeleteCarResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Car")
        .WithDescription("Delete Car");
    }
}
