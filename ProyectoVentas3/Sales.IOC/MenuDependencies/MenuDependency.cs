using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.MenuDependencies
{
    public static class MenuDependency
    {
        public static void AddMenuDependency(this IServiceCollection services)
        {
            services.AddScoped<IMenuDb, MenuDb>();
            services.AddTransient<IMenuService, MenuService>();
        }
    }
}
