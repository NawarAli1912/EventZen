using EventZen.Modules.Ticketing.Application.Tickets.GetTicket;
using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Tickets.GetTicketByCode;

public sealed record GetTicketByCodeQuery(string Code) : IQuery<TicketResponse>;
