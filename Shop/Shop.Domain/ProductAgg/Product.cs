using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;
using System;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public int SubCategoryId { get; private set; }
        public int SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        private Product() { }
        public Product(string title, string imageName, string description, int categoryId,
          int subCategoryId, int secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, imageName, slug, description, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Edit(string title, string imageName, string description, int categoryId,
        int subCategoryId, int secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, imageName, slug, description, domainService);

            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;

            Images.Add(image);
        }

        public void RemoveImage(long imageId)
        {
            var currentImage = Images.FirstOrDefault(i => i.Id == imageId);
            if (currentImage == null)
                throw new InvalidDomainDataException("عکس یافت نشد");

            Images.Remove(currentImage);
        }

        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);
            Specifications = specifications;
        }

        public void Guard(string title, string imageName, string slug, string Description
            , IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(Description, nameof(Description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDuplicateException();
        }
    }
}
