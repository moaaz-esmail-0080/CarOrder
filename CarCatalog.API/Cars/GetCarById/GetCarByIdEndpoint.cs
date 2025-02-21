

namespace CarCatalog.API.Cars.GetCarById;

//public record GetCarByIdRequest();
public record GetCarByIdResponse(Models.Cars car);

public class GetCarByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cars/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetCarByIdQuery(id));

            var response = result.Adapt<GetCarByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCarById")
        .Produces<GetCarByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Car By Id")
        .WithDescription("Get Car By Id");
    }
}
