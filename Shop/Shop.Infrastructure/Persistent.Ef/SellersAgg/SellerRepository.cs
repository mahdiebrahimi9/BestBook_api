using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilites;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.SellersAgg
{
    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        private readonly DapperContext _dapperContext;
        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        //public async Task<InventoryResult?> GetInventoryById(long id)
        //{
        //    return await Context.Inventorys.Where(f => f.Id == id)
        //        .Select(i => new InventoryResult()
        //        {
        //            Count = i.Count,
        //            Id = i.Id,
        //            Price = i.Price,
        //            ProductId = i.ProductId,
        //            SellerId = i.SellerId
        //        }).FirstOrDefaultAsync();
        //}
        public async Task<InventoryResult?> GetInventoryById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"Select * from {_dapperContext.Inventories} where Id=@id";
            return await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql, new { id = id });
        }
    }
}
