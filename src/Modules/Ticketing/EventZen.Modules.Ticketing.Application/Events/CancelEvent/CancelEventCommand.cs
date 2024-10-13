using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
