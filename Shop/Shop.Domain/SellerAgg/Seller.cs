using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventorys { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        private Seller() { }
        
        public Seller(long userId, string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);

            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventorys = new List<SellerInventory>();
        }

        public void Edit(string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);

            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if (Inventorys.Any(i => i.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است");

            Inventorys.Add(inventory);
        }

        public void EditInventory(SellerInventory inventory)
        {
            var oldinventory = Inventorys.FirstOrDefault(i => i.Id == inventory.Id);

            if (oldinventory == null)
                throw new InvalidDomainDataException("محصول یافت نشد");

            Inventorys.Remove(oldinventory);
            Inventorys.Add(inventory);
        }

        public void RemoveInventory(long inventory)
        {
            var currentInventory = Inventorys.FirstOrDefault(i => i.Id == inventory);

            if (currentInventory == null)
                throw new InvalidDomainDataException("محصول یافت نشد");

            Inventorys.Remove(currentInventory);
        }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }
}
