using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.SaleDependencies
{
    public static class SaleDependency
    {
        public static void AddSaleDependency(this IServiceCollection services)
        {
            services.AddScoped<ISaleDb, SaleDb>();
            services.AddTransient<ISaleService, SaleService>();
        }
    }
}
