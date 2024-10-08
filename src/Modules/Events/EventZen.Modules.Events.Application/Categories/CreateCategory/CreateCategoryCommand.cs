using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand<Guid>;
