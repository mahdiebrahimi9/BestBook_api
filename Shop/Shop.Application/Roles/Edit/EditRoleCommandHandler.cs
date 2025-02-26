using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit;

public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    private readonly IRoleRepository _repository;

    public EditRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _repository.GetTracking(request.id);
        if (role == null)
            return OperationResult.NotFound();
        role.Edit(request.title);

        var rolePermission = new List<RolePermission>();
        request.permissions.ForEach(f =>
        {
            rolePermission.Add(new RolePermission(f));
        });
        role.SetPermission(rolePermission);
        await _repository.Save();
        return OperationResult.Success();
    }
}