using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;
