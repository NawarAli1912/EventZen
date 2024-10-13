using EventZen.Modules.Ticketing.Application.Tickets.GetTicket;
using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Tickets.GetTicketForOrder;

public sealed record GetTicketsForOrderQuery(Guid OrderId) : IQuery<IReadOnlyCollection<TicketResponse>>;
