using EventZen.Shared.Domain.Abstractions;
using MediatR;

namespace EventZen.Shared.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;
