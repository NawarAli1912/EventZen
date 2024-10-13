using EventZen.Shared.Application.Messaging;
using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Ticketing.Application.Carts.AddItemToCart;

public sealed record AddItemToCartCommand(Guid CustomerId, Guid TicketTypeId, decimal Quantity) : ICommand;


internal sealed class AddItemToCartCommandHandler(CartService cartService)
    : ICommandHandler<AddItemToCartCommand>
{
    public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        await cartService.ClearAsync(request.CustomerId, cancellationToken);
        // 1. Get customer
        // 2. Get ticket type
        // 3. Add item to cart

        return Result.Success();
    }
}
