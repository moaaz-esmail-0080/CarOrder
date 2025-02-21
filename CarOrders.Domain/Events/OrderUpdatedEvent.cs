using CarOrders.Domain.Abstractions;

namespace CarOrders.Domain.Events;

public record OrderUpdatedEvent(Order order) : IDomainEvent;
