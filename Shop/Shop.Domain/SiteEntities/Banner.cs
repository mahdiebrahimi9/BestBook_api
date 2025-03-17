using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Domain.SiteEntities
{
    public class Banner:BaseEntity
    {
        private Banner() { }

        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public BannerPosition Position { get; private set; }

        public Banner(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);

            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Edit(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);

            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Guard(string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        }
    }
}
