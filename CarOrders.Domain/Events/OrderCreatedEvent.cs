using CarOrders.Domain.Abstractions;

namespace CarOrders.Domain.Events;

public record OrderCreatedEvent(Order order) : IDomainEvent;
