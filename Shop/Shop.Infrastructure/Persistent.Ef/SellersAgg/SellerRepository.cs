using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilites;

namespace Shop.Infrastructure.Persistent.Ef.SellersAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            return await Context.Inventorys.Where(f => f.Id == id)
                .Select(i => new InventoryResult()
                {
                    Count = i.Count,
                    Id = i.Id,
                    Price = i.Price,
                    ProductId = i.ProductId,
                    SellerId = i.SellerId
                }).FirstOrDefaultAsync();
        }
    }
}
