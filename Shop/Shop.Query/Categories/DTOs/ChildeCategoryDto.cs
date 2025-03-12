using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.Categories.DTOs;

public class ChildeCategoryDto:BaseDto
{
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
    public string Slug { get; set; }
    public long? ParentId { get; set; }
    public List<SecondaryChildeCategoryDto> Childs { get; set; }
}