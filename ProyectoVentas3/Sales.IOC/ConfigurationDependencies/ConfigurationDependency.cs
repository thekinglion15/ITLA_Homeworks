using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.ConfigurationDependencies
{
    public static class ConfigurationDependency
    {
        public static void AddConfigurationDependency(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationDb, ConfigurationDb>();
            services.AddTransient<IConfigurationService, ConfigurationService>();
        }
    }
}
