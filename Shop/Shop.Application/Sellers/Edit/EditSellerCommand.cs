using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long id, string shopName, string nationalCode, SellerStatus status) : IBaseCommand;
}
