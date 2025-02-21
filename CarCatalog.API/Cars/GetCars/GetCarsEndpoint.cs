namespace CarCatalog.API.Cars.GetCars;

public record GetCarsRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetCarsResponse(IEnumerable<Models.Cars> Car);

public class GetCarsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cars", async ([AsParameters] GetCarsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetCarsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetCarsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCars")
        .Produces<GetCarsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Cars")
        .WithDescription("Get Cars");
    }
}
