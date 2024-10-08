using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;
