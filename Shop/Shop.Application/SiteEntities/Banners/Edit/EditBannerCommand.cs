using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommand : IBaseCommand
{
    public EditBannerCommand(long id, string link, IFormFile imageName, BannerPosition position)
    {
        Id = id;
        Link = link;
        ImageName = imageName;
        Position = position;
    }
    public long Id { get;private set; }
    public string Link { get; private set; }
    public IFormFile? ImageName { get; private set; }
    public BannerPosition Position { get; private set; }
}