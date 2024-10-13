using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Ticketing.Application.Tickets.CreateTicketBatch;

public sealed record CreateTicketBatchCommand(Guid OrderId) : ICommand;
