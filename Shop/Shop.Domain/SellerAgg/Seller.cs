using System.Runtime.Intrinsics.Arm;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

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

        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);


            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventorys = new List<SellerInventory>();

            if (domainService.CheckSellerInfo(this) == false)
                throw new InvalidDomainDataException("اطلاعات نامعتبر است");
        }

        public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);

            if (nationalCode != NationalCode)
            {
                if (domainService.NationalCodeExistInDataBase(nationalCode))
                {
                    throw new InvalidDomainDataException("کد ملی متعلق به شخص دیگری است");
                }
            }

            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
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

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var oldinventory = Inventorys.FirstOrDefault(i => i.Id == inventoryId);
            if (oldinventory == null)
                throw new InvalidDomainDataException("محصول یافت نشد");

            oldinventory.Edit(count, price, discountPercentage);
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
