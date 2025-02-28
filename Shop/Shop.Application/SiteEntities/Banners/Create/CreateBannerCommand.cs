using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommand : IBaseCommand
    {
        public CreateBannerCommand(string link, IFormFile imageName, BannerPosition position)
        {
            Link = link;
            ImageName = imageName;
            Position = position;
        }
        public string Link { get; private set; }
        public IFormFile ImageName { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
