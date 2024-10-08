using EventZen.Modules.Events.Application.Abstractions.Messaging;

namespace EventZen.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) : IQuery<EventResponse>;
