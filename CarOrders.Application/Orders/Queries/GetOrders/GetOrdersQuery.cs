using CarOrders.Application.Dtos;
using MessageCore.CQRS;
using MessageCore.Pagination;

namespace CarOrders.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) 
    : IQuery<GetOrdersResult>;

public record GetOrdersResult(PaginatedResult<OrderDto> Orders);