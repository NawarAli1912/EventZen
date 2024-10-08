using EventZen.Modules.Events.Application.Categories.GetCategory;
using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
