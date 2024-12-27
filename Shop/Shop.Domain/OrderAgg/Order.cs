using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order() { }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem>? Items { get; private set; }
        public OrderAddress? Address { get; set; }
        public OrderDiscount Discount { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }

        public DateTime? LastUpdate { get; private set; }
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);

                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }
        public int TotalCount => Items.Count;

        public void AddItem(OrderItem item)
        {
            ChangeOrderGuard();

            var oldItem = Items.FirstOrDefault(i => i.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                item.ChangeCount(item.Count + oldItem.Count);
                return;
            }

            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void ChangeCountItem(long itemId, int newCount)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);

            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.ChangeCount(newCount);

        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void CheckOut(OrderAddress address)
        {
            ChangeOrderGuard();
            Address = address;
        }

        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pennding)
                throw new InvalidDomainDataException("امکان ثبت محصول در این سفارش وجود ندارد");
        }
    }
}
