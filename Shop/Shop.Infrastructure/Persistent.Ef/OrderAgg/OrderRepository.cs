using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructure._Utilites;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }

        public Task<Order> GetCurrentUserOrder(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
