using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.ProductDependencies
{
    public static class ProductDependency
    {
        public static void AddProductDependency(this IServiceCollection services)
        {
            services.AddScoped<IProductDb, ProductDb>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
