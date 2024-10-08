using EventZen.Modules.Events.Domain.Abstractions;

namespace EventZen.Modules.Events.Domain.Categories;

public sealed class CategoryCreatedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
