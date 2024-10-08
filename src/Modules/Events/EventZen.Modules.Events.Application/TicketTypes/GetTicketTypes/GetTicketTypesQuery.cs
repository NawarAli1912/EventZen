using EventZen.Modules.Events.Application.TicketTypes.GetTicketType;
using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
