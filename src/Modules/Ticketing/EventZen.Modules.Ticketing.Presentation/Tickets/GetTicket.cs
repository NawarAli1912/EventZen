using EventZen.Modules.Ticketing.Application.Tickets.GetTicket;
using EventZen.Shared.Domain.Abstractions;
using EventZen.Shared.Presentation;
using EventZen.Shared.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventZen.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicket : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("tickets/{id}", async (Guid id, ISender sender) =>
        {
            Result<TicketResponse> result = await sender.Send(new GetTicketQuery(id));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .RequireAuthorization()
        .WithTags(Tags.Tickets);
    }
}
