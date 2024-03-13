using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.RoleMenuDependencies
{
    public static class RoleMenuDependency
    {
        public static void AddRoleMenuDependency(this IServiceCollection services)
        {
            services.AddScoped<IRoleMenuDb, RoleMenuDb>();
            services.AddTransient<IRoleMenuService, RoleMenuService>();
        }
    }
}
