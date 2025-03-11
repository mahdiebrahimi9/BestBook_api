using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UsersAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User");

            builder.OwnsMany(f => f.Addresses, option =>
            {
                option.ToTable("Addresses", "User");
            });

            builder.OwnsMany(f => f.Roles, option =>
            {
                option.ToTable("Roles", "User");
            });

            builder.OwnsMany(f => f.Wallets, option =>
            {
                option.ToTable("Wallets", "User");
            });
        }
    }
}
