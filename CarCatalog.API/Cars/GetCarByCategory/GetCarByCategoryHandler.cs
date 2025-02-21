
using MessageCore.CQRS;

namespace CarCatalog.API.Cars.GetCarByCategory;

public record GetCarByCategoryQuery(string Category) : IQuery<GetCarByCategoryResult>;
public record GetCarByCategoryResult(IEnumerable<Models.Cars> Cars);

internal class GetCarByCategoryQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetCarByCategoryQuery, GetCarByCategoryResult>
{
    public async Task<GetCarByCategoryResult> Handle(GetCarByCategoryQuery query, CancellationToken cancellationToken)
    {
        var cars = await session.Query<Models.Cars>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetCarByCategoryResult(cars);
    }
}
