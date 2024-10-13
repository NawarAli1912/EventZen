
using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Carts.ClearCart;

public sealed record ClearCartCommand(Guid CustomerId) : ICommand;
