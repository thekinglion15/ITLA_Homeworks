using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.CorrelativeNumberDependencies
{
    public static class CorrelativeNumberDependency
    {
        public static void AddCorrelativeNumberDependency(this IServiceCollection services)
        {
            services.AddScoped<ICorrelativeNumberDb, CorrelativeNumberDb>();
            services.AddTransient<ICorrelativeNumberService, CorrelativeNumberService>();
        }
    }
}
