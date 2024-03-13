using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;
using Sales.AppServices.Contracts;
using Sales.AppServices.Service;

namespace Sales.IOC.CategoryDependencies
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDb, CategoryDb>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
