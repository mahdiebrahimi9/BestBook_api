using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects;
using Common.Query;
using Shop.Domain.CategoryAgg;

namespace Shop.Query.Categories.DTOs
{
    public class CategoryDto:BaseDto
    {
        public string Title { get;  set; }
        public SeoData SeoData { get;  set; }
        public string Slug { get;  set; }
        public List<ChildeCategoryDto> Childs { get;  set; }
    }
}
