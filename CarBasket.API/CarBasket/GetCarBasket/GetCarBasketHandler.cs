

using CarBasket.API.Data;
using CarBasket.API.Models;
using MessageCore.CQRS;

namespace CarBasket.API.CarBasket.GetCarBasket;

public record GetCarBasketQuery(string UserName) : IQuery<GetCarBasketResult>;
public record GetCarBasketResult(ShoppingCart Cart);

public class GetCarBasketQueryHandler(ICarBasketRepository repository)
    : IQueryHandler<GetCarBasketQuery, GetCarBasketResult>
{
    public async Task<GetCarBasketResult> Handle(GetCarBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(query.UserName);

        return new GetCarBasketResult(basket);
    }
}
