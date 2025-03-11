using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;

namespace Shop.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Init(this IServiceCollection service)
        {
            service.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
