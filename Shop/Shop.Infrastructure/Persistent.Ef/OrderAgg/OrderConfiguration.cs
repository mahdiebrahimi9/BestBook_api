using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Order");

            // realtion one to one ValueObject
            builder.OwnsOne(f => f.Discount, option =>
            {
                option.Property(f => f.DiscountTitle)
                    .HasMaxLength(50);
            });

            builder.OwnsOne(f => f.ShippingMethod, option =>
            {
                option.Property(f => f.ShippingType)
                    .HasMaxLength(50);
            });

            // relation ont to many Childe
            builder.OwnsMany(f => f.Items, option =>
            {
                option.ToTable("Items", "Order");
            });

            builder.OwnsOne(f => f.Address, option =>
            {
                option.ToTable("Addresses", "Order");
            });
        }
    }
}
