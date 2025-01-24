using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommand : IBaseCommand
    {
        public EditProductCommand(string title, IFormFile imageFile, string description, int categoryId,
            int subCategoryId, int secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }

        public string Title { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public int SubCategoryId { get; private set; }
        public int SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specifications { get; private set; }
    }
}
