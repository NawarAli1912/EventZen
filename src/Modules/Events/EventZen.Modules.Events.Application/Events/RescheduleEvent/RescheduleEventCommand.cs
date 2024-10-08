using EventZen.Modules.Events.Application.Abstractions.Messaging;

namespace EventZen.Modules.Events.Application.Events.RescheduleEvent;

public sealed record RescheduleEventCommand(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc) : ICommand;
