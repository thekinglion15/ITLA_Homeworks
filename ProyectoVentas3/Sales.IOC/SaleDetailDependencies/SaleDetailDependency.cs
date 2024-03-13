using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.SaleDetailDependencies
{
    public static class SaleDetailDependency
    {
        public static void AddSaleDetailDependency(this IServiceCollection services)
        {
            services.AddScoped<ISaleDetailDb, SaleDetailDb>();
            services.AddTransient<ISaleDetailService, SaleDetailService>();
        }
    }
}
