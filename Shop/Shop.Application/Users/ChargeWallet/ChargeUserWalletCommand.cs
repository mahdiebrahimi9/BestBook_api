using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommand : IBaseCommand
    {
        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public WalletType Type { get; private set; }
        public bool IsFinally { get; private set; }
    }
}
