using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ICategoryDb : IDaoBase<Category>
    {
        List<CategoryModel> GetCategoriesByDates(DateTime startDate, DateTime endDate);
        List<CategoryModel> GetCategoriesCount();
        List<CategoryModel> GetCategories();
    }
}
