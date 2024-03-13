using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IMenuService
    {
        ServiceResult GetMenusByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetMenusCount();
        ServiceResult GetMenus();
    }
}
