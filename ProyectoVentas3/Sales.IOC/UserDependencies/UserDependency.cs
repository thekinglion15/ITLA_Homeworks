using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.UserDependencies
{
    public static class UserDependency
    {
        public static void AddUserDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserDb, UserDb>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
