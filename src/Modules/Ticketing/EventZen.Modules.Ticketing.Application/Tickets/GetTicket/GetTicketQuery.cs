using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Tickets.GetTicket;

public sealed record GetTicketQuery(Guid TicketId) : IQuery<TicketResponse>;
