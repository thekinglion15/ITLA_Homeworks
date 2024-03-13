using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IRoleMenuDb : IDaoBase<RoleMenu>
    {
        List<RoleMenuModel> GetRoleMenusByDates(DateTime startDate, DateTime endDate);
        List<RoleMenuModel> GetRoleMenusCount();
        List<RoleMenuModel> GetRoleMenus();
    }
}
