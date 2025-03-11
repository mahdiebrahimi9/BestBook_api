using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure._Utilites;

namespace Shop.Infrastructure.Persistent.Ef.UsersAgg
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }

        public UserAddress GetAddressById(long addressId)
        {
            throw new NotImplementedException();
        }
    }
}
