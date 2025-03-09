using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Order");

            // value object 
            builder.OwnsOne(o => o.Discount, option =>
            {
                option.Property(o => o.DiscountTitle)
                    .HasMaxLength(50);
            });

            builder.OwnsOne(o => o.ShippingMethod, options =>
            {
                options.Property(o => o.ShippingType)
                    .HasMaxLength(50);
            });

            // one to many relation
            builder.OwnsMany(o => o.Items, options =>
            {
                options.ToTable("Items", "Order");
            });

            // one to one relation
            builder.OwnsOne(o => o.Address, options =>
            {
                options.ToTable("Addresses", "Order");

            });
        }
    }
}
