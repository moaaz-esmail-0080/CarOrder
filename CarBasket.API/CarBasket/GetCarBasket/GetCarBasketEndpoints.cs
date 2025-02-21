using CarBasket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace CarBasket.API.CarBasket.GetCarBasket;

//public record GetCarBasketRequest(string UserName); 
public record GetCarBasketResponse(ShoppingCart Cart);

public class GetCarBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetCarBasketQuery(userName));

            var respose = result.Adapt<GetCarBasketResponse>();

            return Results.Ok(respose);
        })
        .WithName("GetProductById")
        .Produces<GetCarBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
