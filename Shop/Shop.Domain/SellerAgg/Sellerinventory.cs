using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }

        public SellerInventory(long productId, int count, int price)
        {
            Guard(count, price);
            ProductId = productId;
            Count = count;
            Price = price;
        }

        public void Edit(int count, int price)
        {
            Guard(count, price);
            Count = count;
            Price = price;
        }

        public void Guard(int count, int price)
        {
            if (count < 0)
                throw new InvalidDomainDataException();

            if (price < 1)
                throw new InvalidDomainDataException();
        }

    }
}
