using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IRoleMenuService
    {
        ServiceResult GetRoleMenusByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetRoleMenusCount();
        ServiceResult GetRoleMenus();
    }
}
