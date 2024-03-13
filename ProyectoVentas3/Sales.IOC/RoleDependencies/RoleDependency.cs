using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.RoleDependencies
{
    public static class RoleDependency
    {
        public static void AddRoleDependency(this IServiceCollection services)
        {
            services.AddScoped<IRoleDb, RoleDb>();
            services.AddTransient<IRoleService, RoleService>();
        }
    }
}
