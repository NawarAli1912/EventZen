using EventZen.Modules.Users.Application.Users.GetUser;
using EventZen.Modules.Users.Domain.Users;
using EventZen.Modules.Users.IntegrationEvents;
using EventZen.Shared.Application.EventBus;
using EventZen.Shared.Application.Exceptions;
using EventZen.Shared.Application.Messaging;
using EventZen.Shared.Domain.Abstractions;
using MediatR;

namespace EventZen.Modules.Users.Application.Users.RegisterUser;
public class UserRegisteredDomainEventHandler(ISender sender, IEventBus eventBus) : IDomainEventHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        Result<UserResponse> result = await sender.Send(new GetUserQuery(notification.UserId), cancellationToken);

        if (result.IsFailure)
        {
            throw new EventZenException(nameof(GetUserQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new UserRegisteredIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName
            ),
            cancellationToken
        );
    }
}
