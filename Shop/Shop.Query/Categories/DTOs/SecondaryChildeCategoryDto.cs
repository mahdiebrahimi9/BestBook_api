﻿using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.Categories.DTOs;

public class SecondaryChildeCategoryDto:BaseDto
{
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
    public string Slug { get; set; }
    public long? ParentId { get; set; }
}