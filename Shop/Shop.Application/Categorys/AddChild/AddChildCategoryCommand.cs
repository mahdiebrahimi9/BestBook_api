﻿using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categorys.AddChild
{
    public record AddChildCategoryCommand(long parentId, string title, string slug, SeoData seoData) : IBaseCommand;
}
