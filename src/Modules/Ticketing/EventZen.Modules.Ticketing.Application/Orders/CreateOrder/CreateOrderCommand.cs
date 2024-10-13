using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(Guid CustomerId) : ICommand;
