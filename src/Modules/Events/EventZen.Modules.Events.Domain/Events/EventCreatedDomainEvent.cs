using EventZen.Modules.Events.Domain.Abstractions;

namespace EventZen.Modules.Events.Domain.Events;
public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
