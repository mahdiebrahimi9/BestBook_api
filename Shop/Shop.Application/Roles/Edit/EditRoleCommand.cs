using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Roles.Edit
{
    public record EditRoleCommand(long id, string title, List<Permission> permissions) : IBaseCommand;
}
