using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Categories.ArchiveCategory;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : ICommand;
