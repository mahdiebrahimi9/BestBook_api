using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommand : IBaseCommand
    {
        public AddSellerInventoryCommand(long sellerId, long productId, int count, int price, int? percentageDiscount)
        {
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            PercentageDiscount = percentageDiscount;
        }

        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PercentageDiscount { get; private set; }
    }
}
