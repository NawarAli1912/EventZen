﻿using System.Data.Common;
using EventZen.Modules.Ticketing.Application.Abstraction.Data;
using EventZen.Modules.Ticketing.Domain.Events;
using EventZen.Modules.Ticketing.Domain.Tickets;
using EventZen.Shared.Application.Messaging;
using EventZen.Shared.Domain.Abstractions;

namespace EventZen.Modules.Ticketing.Application.Tickets.ArchiveTicketsForEvent;

internal sealed class ArchiveTicketsForEventCommandHandler(
    IEventRepository eventRepository,
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ArchiveTicketsForEventCommand>
{
    public async Task<Result> Handle(ArchiveTicketsForEventCommand request, CancellationToken cancellationToken)
    {
        await using DbTransaction transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);

        Event? @event = await eventRepository.GetAsync(request.EventId, cancellationToken);

        if (@event is null)
        {
            return Result.Failure(EventErrors.NotFound(request.EventId));
        }

        IEnumerable<Ticket> tickets = await ticketRepository.GetForEventAsync(@event, cancellationToken);

        foreach (Ticket ticket in tickets)
        {
            ticket.Archive();
        }

        @event.TicketsArchived();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
