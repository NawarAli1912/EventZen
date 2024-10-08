using EventZen.Modules.Events.Application.Abstractions.Messaging;
using EventZen.Modules.Events.Application.TicketTypes.GetTicketType;

namespace EventZen.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
