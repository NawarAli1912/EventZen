using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Carts.GetCart;

public sealed record GetCartQuery(Guid CustomerId) : IQuery<Cart>;
