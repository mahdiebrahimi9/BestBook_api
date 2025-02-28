using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand : IBaseCommand
    {
        public EditSliderCommand(long id, string link, string title, IFormFile? imageName)
        {
            Id = id;
            Link = link;
            Title = title;
            ImageName = imageName;
        }
        public long Id { get; private set; }
        public string Link { get; private set; }
        public string Title { get; private set; }
        public IFormFile? ImageName { get; private set; }
    }
}
