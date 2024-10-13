using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Orders.GetOrder;

public sealed record GetOrderQuery(Guid OrderId) : IQuery<OrderResponse>;
