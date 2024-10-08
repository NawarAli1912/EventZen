using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Events.SearchEvents;
public sealed record SearchEventsQuery(
    Guid? CategoryId,
    DateTime? StartDate,
    DateTime? EndDate,
    int Page,
    int PageSize) : IQuery<SearchEventsResponse>;

