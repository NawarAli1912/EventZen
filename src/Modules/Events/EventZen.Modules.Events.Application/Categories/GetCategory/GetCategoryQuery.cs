using EventZen.Shared.Application.Messaging;

namespace EventZen.Modules.Events.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
