using EventZen.Modules.Ticketing.Application.Customers.CreateCustomer;
using EventZen.Modules.Users.IntegrationEvents;
using EventZen.Shared.Application.Exceptions;
using EventZen.Shared.Domain.Abstractions;
using MassTransit;
using MediatR;

namespace EventZen.Modules.Ticketing.Presentation.Customers;
public sealed class UserRegisteredIntegrationEventConsumer(ISender sender) : IConsumer<UserRegisteredIntegrationEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredIntegrationEvent> context)
    {
        Result result = await sender.Send(
            new CreateCustomerCommand(
                context.Message.UserId,
                context.Message.Email,
                context.Message.FirstName,
                context.Message.LastName));

        if (result.IsFailure)
        {
            throw new EventZenException(nameof(CreateCustomerCommand), result.Error);
        }
    }
}
