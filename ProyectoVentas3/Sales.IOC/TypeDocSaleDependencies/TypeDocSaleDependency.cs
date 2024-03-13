using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.TypeDocSaleDependencies
{
    public static class TypeDocSaleDependency
    {
        public static void AddTypeDocSaleDependency(this IServiceCollection services)
        {
            services.AddScoped<ITypeDocSaleDb, TypeDocSaleDb>();
            services.AddTransient<ITypeDocSaleService, TypeDocSaleService>();
        }
    }
}
