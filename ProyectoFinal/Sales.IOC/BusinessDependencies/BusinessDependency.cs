using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.BusinessDependencies
{
    public static class BusinessDependency
    {
        public static void AddBusinessDependency(this IServiceCollection services)
        {
            services.AddScoped<IBusinessDb, BusinessDb>();
            services.AddTransient<IBusinessService, BusinessService>();
        }
    }
}
