﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public Wallet(int price, string description, WalletType type, bool isFinally)
        {
            if (price < 500)
                throw new InvalidDomainDataException();

            Price = price;
            Description = description;
            Type = type;
            IsFinally = isFinally;
            if (isFinally)
                FinallyDate = DateTime.Now;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public WalletType Type { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }

        public void Finally(string refCode)
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            Description += $"کد چیگیری: {refCode}";
        }
        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }
    }
}
