using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilites;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
{
    private readonly IBannerRepository _bannerRepository;
    private readonly IFileService _fileService;

    public CreateBannerCommandHandler(IFileService fileService, IBannerRepository bannerRepository)
    {
        _fileService = fileService;
        _bannerRepository = bannerRepository;
    }

    public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageName, Directories.BannerImage);
        var banner = new Banner(request.Link, imageName, request.Position);
        _bannerRepository.Add(banner);
        await _bannerRepository.Save();
        return OperationResult.Success();
    }
}