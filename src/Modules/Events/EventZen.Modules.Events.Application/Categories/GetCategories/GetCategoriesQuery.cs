using EventZen.Modules.Events.Application.Abstractions.Messaging;
using EventZen.Modules.Events.Application.Categories.GetCategory;

namespace EventZen.Modules.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
