using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilites;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductDomainService _productDomain;
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public EditProductCommandHandler(IProductDomainService productDomain, IProductRepository productRepository, IFileService fileService)
        {
            _productDomain = productDomain;
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.CategoryId);
            if (product == null)
                return OperationResult.NotFound();
            product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId
                , request.SecondarySubCategoryId, request.Slug, request.SeoData, _productDomain);
            var oldImage = product.ImageName;
            if (request.ImageFile != null)
            {
                var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImage);
                product.SetProductImage(imageName);
            }

            var specifcations = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifcations.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifcations);
            await _productRepository.Save();
            RemoveOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile != null)
            {
                _fileService.DeleteFile(Directories.ProductImage, oldImageName);

            }
        }
    }
}
