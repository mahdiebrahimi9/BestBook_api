using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repository;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellersAgg;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Banners;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Sliders;
using Shop.Infrastructure.Persistent.Ef.UsersAgg;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IRoleRepository, RoleRepository>();
            service.AddTransient<ISellerRepository, SellerRepository>();
            service.AddTransient<IBannerRepository, BannerRepository>();
            service.AddTransient<ISliderRepository, SliderRepository>();
            service.AddTransient<IUserRepository, UserRepository>();

            service.AddTransient(_ => new DapperContext(connectionString));
            service.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

        }
    }
}
