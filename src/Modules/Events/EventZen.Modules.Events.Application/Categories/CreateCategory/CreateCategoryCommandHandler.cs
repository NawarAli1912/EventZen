using EventZen.Modules.Events.Application.Abstractions.Data;
using EventZen.Modules.Events.Application.Abstractions.Messaging;
using EventZen.Modules.Events.Domain.Abstractions;
using EventZen.Modules.Events.Domain.Categories;

namespace EventZen.Modules.Events.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name);

        categoryRepository.Insert(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
