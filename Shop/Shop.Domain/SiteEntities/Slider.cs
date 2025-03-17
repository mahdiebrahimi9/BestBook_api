﻿using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        private Slider() { }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }

        public Slider(string title, string link, string imageName)
        {
            Guard(title, imageName, link);

            Title = title;
            Link = link;
            ImageName = imageName;
        }

        public void Edit(string title, string imageName, string link)
        {
            Guard(title, imageName, link);

            Title = title;
            Link = link;
            ImageName = imageName;
        }

        public void Guard(string title, string imageName, string link)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));

        }
    }
}
