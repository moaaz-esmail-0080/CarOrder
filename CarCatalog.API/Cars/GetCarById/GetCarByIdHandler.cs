using CarCatalog.API.Exceptions;
using MessageCore.CQRS;

namespace CarCatalog.API.Cars.GetCarById;

public record GetCarByIdQuery(Guid Id) : IQuery<GetCarByIdResult>;
public record GetCarByIdResult(Models.Cars Car);

internal class GetCarByIdQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetCarByIdQuery, GetCarByIdResult>
{
    public async Task<GetCarByIdResult> Handle(GetCarByIdQuery query, CancellationToken cancellationToken)
    {
        var car = await session.LoadAsync<Models.Cars>(query.Id, cancellationToken);

        if (car is null)
        {
            throw new CarsNotFoundException(query.Id);
        }

        return new GetCarByIdResult(car);
    }
}
