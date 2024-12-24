using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categorys.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.id);
            if (category == null)
                OperationResult.NotFound();

            category.Edit(request.title, request.slug, request.seoData, _domainService);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}
