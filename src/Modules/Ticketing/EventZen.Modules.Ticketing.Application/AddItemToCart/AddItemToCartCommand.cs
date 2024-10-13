using EventZen.Modules.Ticketing.Application.Carts;
using EventZen.Shared.Application.Messaging;
using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Ticketing.Application.AddItemToCart;

public sealed record AddItemToCartCommand(Guid CustomerId, Guid TicketTypeId, decimal Quantity) : ICommand;


internal sealed class AddItemToCartCommandHandler(CartService cartService)
    : ICommandHandler<AddItemToCartCommand>
{
    public Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        // 1. Get customer
        // 2. Get ticket type
        // 3. Add item to cart

        return Task.FromResult(Result.Success());
    }
}
