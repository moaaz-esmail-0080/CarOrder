using Carter;
using Mapster;
using MediatR;

namespace CarBasket.API.CarBasket.DeleteCarBasket;

//public record DeleteBasketRequest(string UserName);
public record DeleteCarBasketResponse(bool IsSuccess);

public class DeleteCarBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteCarBasketCommand(userName));

            var response = result.Adapt<DeleteCarBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<DeleteCarBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}
