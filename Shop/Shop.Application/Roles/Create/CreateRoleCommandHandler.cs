using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var rolePermission = new List<RolePermission>();
        request.permissions.ForEach(f =>
        {
            rolePermission.Add(new RolePermission(f));
        });
        var role = new Role(request.title, rolePermission);
        await _roleRepository.AddAsync(role);
        await _roleRepository.Save();
        return OperationResult.Success();
    }
}