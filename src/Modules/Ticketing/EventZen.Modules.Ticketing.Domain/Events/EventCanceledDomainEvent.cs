using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Ticketing.Domain.Events;

public sealed class EventCanceledDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; } = eventId;
}
