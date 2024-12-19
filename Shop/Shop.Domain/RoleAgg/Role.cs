using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        public string Title { get; private set; }
        public List<RolePermission> Permissions { get; private set; }

        private Role() { }
        public Role(string title, List<RolePermission> permissions)
        {
            Guard(title);

            Title = title;
            Permissions = permissions;
        }

        public Role(string title)
        {
            Guard(title);

            Title = title;
            Permissions = new List<RolePermission>();
        }

        public void Edit(string title)
        {
            Guard(title);

            Title = title;
        }

        public void SetPermission(List<RolePermission> permissions)
        {
            Permissions = permissions;
        }

        private void Guard(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        }

    }
}
