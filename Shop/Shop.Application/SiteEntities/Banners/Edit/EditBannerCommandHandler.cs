using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilites;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerRepository _bannerRepository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IFileService fileService, IBannerRepository bannerRepository)
    {
        _fileService = fileService;
        _bannerRepository = bannerRepository;
    }

    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _bannerRepository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();

        var imageName = banner.ImageName;
        var oldImage = banner.ImageName;

        if (request.ImageName != null)
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageName, Directories.BannerImage);
        banner.Edit(request.Link, imageName, request.Position);
        await _bannerRepository.Save();
        DeleteOldImage(request.ImageName, oldImage);
        return OperationResult.Success();
    }
    private void DeleteOldImage(IFormFile? imageName, string oldImage)
    {
        if (imageName != null)
        {
            _fileService.DeleteFile(Directories.SliderImage, oldImage);
        }
    }
}