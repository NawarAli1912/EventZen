using EventZen.Modules.Events.Application.Abstractions.Messaging;

namespace EventZen.Modules.Events.Application.Categories.ArchiveCategory;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : ICommand;
