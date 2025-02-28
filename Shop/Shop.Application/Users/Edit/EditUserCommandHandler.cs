using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilites;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IDomainUserService _domainUserService;
    private readonly IFileService _fileService;
    public EditUserCommandHandler(IUserRepository userRepository, IDomainUserService domainUserService, IFileService fileService)
    {
        _userRepository = userRepository;
        _domainUserService = domainUserService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        var oldAvatar = user.AvatarName;
        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _domainUserService);

        if (request.Avatar != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatar);
            user.SetAvatar(imageName);
        }

        DeleteOldAvatar(request.Avatar, oldAvatar);
        await _userRepository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldAvatar(IFormFile? avatarFile, string oldImage)
    {
        if (avatarFile == null || oldImage == "avatar.png")
            return;

        _fileService.DeleteFile(Directories.UserAvatar, oldImage);
    }

}