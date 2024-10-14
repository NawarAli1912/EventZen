﻿using EventZen.Modules.Ticketing.Application.Carts.AddItemToCart;
using EventZen.Shared.Domain.Abstractions;
using EventZen.Shared.Presentation;
using EventZen.Shared.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventZen.Modules.Ticketing.Presentation.Carts;

internal sealed class AddToCart : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("carts/add", async (Request request, ISender sender) =>
        {
            Result result = await sender.Send(
                new AddItemToCartCommand(
                    request.CustomerId,
                    request.TicketTypeId,
                    request.Quantity));

            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
        .RequireAuthorization()
        .WithTags(Tags.Carts);
    }

    internal sealed class Request
    {
        public Guid CustomerId { get; init; }

        public Guid TicketTypeId { get; init; }

        public decimal Quantity { get; init; }
    }
}
