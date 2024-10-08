using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
