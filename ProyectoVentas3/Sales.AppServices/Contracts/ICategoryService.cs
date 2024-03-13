using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface ICategoryService
    {
        ServiceResult GetCategoriesByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetCategoriesCount();
        ServiceResult GetCategories();
    }
}
