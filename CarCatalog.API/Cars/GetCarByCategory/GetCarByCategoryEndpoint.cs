namespace CarCatalog.API.Cars.GetCarByCategory;

//public record GetCarByCategoryRequest();
public record GetCarByCategoryResponse(IEnumerable<Models.Cars> Cars);

public class GetCarByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cars/category/{category}",
            async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetCarByCategoryQuery(category));

                var response = result.Adapt<GetCarByCategoryResponse>();

                return Results.Ok(response);
            })
        .WithName("GetCarByCategory")
        .Produces<GetCarByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Car By Category")
        .WithDescription("Get Car By Category");
    }
}
