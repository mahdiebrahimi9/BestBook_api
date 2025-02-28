using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Sellers.EditInventory
{
    public class EditInventoryCommand : IBaseCommand
    {
        public EditInventoryCommand(long sellerId, int count, int price, int? percentageDiscount, long inventoryId)
        {
            SellerId = sellerId;
            Count = count;
            Price = price;
            PercentageDiscount = percentageDiscount;
            InventoryId = inventoryId;
        }
        public long SellerId { get; private set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PercentageDiscount { get; private set; }
    }
}
