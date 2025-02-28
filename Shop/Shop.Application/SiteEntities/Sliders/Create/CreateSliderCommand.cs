using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommand : IBaseCommand
    {
        public CreateSliderCommand(string link, string title, IFormFile imageName)
        {
            Link = link;
            Title = title;
            ImageName = imageName;
        }
        public string Link { get; private set; }
        public string Title { get; private set; }
        public IFormFile ImageName { get; private set; }
    }
}
