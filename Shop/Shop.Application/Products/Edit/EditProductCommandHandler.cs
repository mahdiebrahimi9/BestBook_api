using Common.Application;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductDomainService _productDomain;
        private readonly IProductRepository _productRepository;

        public EditProductCommandHandler(IProductDomainService productDomain, IProductRepository productRepository)
        {
            _productDomain = productDomain;
            _productRepository = productRepository;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.CategoryId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
        }
    }
}
