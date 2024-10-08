using EventZen.Modules.Events.Application.Abstractions.Messaging;

namespace EventZen.Modules.Events.Application.TicketTypes.GetTicketType;

public sealed record GetTicketTypeQuery(Guid TicketTypeId) : IQuery<TicketTypeResponse>;
