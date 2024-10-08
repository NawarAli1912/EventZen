using EventZen.Modules.Events.Application.Abstractions.Messaging;

namespace EventZen.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;
