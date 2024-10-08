using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Events.PublishEvent;

public sealed record PublishEventCommand(Guid EventId) : ICommand;
