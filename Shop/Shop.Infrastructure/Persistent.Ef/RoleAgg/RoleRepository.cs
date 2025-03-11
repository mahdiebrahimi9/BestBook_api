﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilites;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    public class RoleRepository:BaseRepository<Role>,IRoleRepository
    {
        public RoleRepository(ShopContext context) : base(context)
        {
        }
    }
}
