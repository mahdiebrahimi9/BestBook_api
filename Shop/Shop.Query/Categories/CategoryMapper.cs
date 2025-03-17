using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null)
                return null;
            return new CategoryDto()
            {
                Id = category.Id,
                SeoData = category.SeoData,
                CreationData = category.CreationDate,
                Slug = category.Slug,
                Title = category.Title,
                Childs = category.Childs.MapChildren()

            };
        }

        public static List<CategoryDto> Map(this List<Category>? category)
        {

            var model = new List<CategoryDto>();
            category.ForEach(category =>
            {
                model.Add(new CategoryDto()
                {
                    Id = category.Id,
                    SeoData = category.SeoData,
                    CreationData = category.CreationDate,
                    Slug = category.Slug,
                    Title = category.Title,
                    Childs = category.Childs.MapChildren()

                });
            });
            return model;
        }

        public static List<ChildeCategoryDto> MapChildren(this List<Category> children)
        {
            var model = new List<ChildeCategoryDto>();
            children.ForEach(c =>
            {
                model.Add(new ChildeCategoryDto()
                {
                    Id = c.Id,
                    SeoData = c.SeoData,
                    CreationData = c.CreationDate,
                    Slug = c.Slug,
                    Title = c.Title,
                    ParentId = (long)c.ParentId,
                    Childs = c.Childs.MapSecondaryChild()

                });
            });
            return model;
        }
        private static List<SecondaryChildeCategoryDto> MapSecondaryChild(this List<Category> children)
        {
            var model = new List<SecondaryChildeCategoryDto>();
            children.ForEach(c =>
            {
                model.Add(new SecondaryChildeCategoryDto()
                {
                    Id = c.Id,
                    SeoData = c.SeoData,
                    CreationData = c.CreationDate,
                    Slug = c.Slug,
                    Title = c.Title,
                    ParentId = (long)c.ParentId,


                });
            });
            return model;
        }
    }
}
