using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Users.Domain.Users;

public sealed class UserRegisteredDomainEvent(Guid userId) : DomainEvent
{
    public Guid UserId { get; init; } = userId;
}
