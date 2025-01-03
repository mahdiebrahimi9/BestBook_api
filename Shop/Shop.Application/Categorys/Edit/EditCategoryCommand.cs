﻿using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categorys.Edit
{
    public record EditCategoryCommand(long id, string title, string slug, SeoData seoData) : IBaseCommand;
}
