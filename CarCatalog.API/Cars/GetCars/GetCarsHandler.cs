

using MessageCore.CQRS;

namespace CarCatalog.API.Cars.GetCars;

public record GetCarsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetCarsResult>;
public record GetCarsResult(IEnumerable<Models.Cars> Car);

internal class GetCarsQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetCarsQuery, GetCarsResult>
{
    public async Task<GetCarsResult> Handle(GetCarsQuery query, CancellationToken cancellationToken)
    {
        var cars = await session.Query<Models.Cars>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetCarsResult(cars);
    }
}
