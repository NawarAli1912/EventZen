using EventZen.Shared.Application.EventBus;
using MassTransit;

namespace EventZen.Shared.Infrastructure.EventBus;
internal sealed class EventBus(IBus bus) : IEventBus
{
    public Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default) where T : class, IIntegrationEvent
    {
        return bus.Publish(integrationEvent, cancellationToken);
    }
}
