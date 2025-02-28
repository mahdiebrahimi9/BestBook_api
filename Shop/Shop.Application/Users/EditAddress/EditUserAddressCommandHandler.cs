using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress;

public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public EditUserAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();
        var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.Name, request.Family, request.PostalAddress, request.PhoneNumber, request.NationalCode);
        user.EditAddress(address, request.Id);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}