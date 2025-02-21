using CarBasket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace CarBasket.API.CarBasket.StoreCarBasket;

public record StoreCarBasketRequest(ShoppingCart Cart);
public record StoreCarBasketResponse(string UserName);

public class StoreCarBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreCarBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreCarBasketCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<StoreCarBasketResponse>();

            return Results.Created($"/basket/{response.UserName}", response);
        })
        .WithName("CreateProduct")
        .Produces<StoreCarBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
