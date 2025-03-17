using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        private Category (){}
        public string Title { get; private set; }
        public SeoData SeoData { get; private set; }
        public string Slug { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> Childs { get; private set; }

        public Category(string title, SeoData seoData, string slug, ICategoryDomainService domainService)
        {
            Guard(title, slug, domainService);

            slug = slug.ToSlug();
            Title = title;
            SeoData = seoData;
            Slug = slug;
        }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
        {
            Guard(title, slug, domainService);

            slug.ToSlug();
            Title = title;
            SeoData = seoData;
            Slug = slug;
        }
        public void AddChild(string title, SeoData seoData, string slug, ICategoryDomainService domainService)
        {
            Childs.Add(new Category(title, seoData, slug, domainService)
            {
                ParentId = Id
            });
        }

        public void Guard(string title, string slug, ICategoryDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.IsSlugExist(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}
