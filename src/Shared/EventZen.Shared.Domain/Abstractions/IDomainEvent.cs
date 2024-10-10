using MediatR;

namespace EventZen.Shared.Domain.Abstractions;


public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
