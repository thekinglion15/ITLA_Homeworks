using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IMenuDb : IDaoBase<Menu>
    {
        List<MenuModel> GetMenusByDates(DateTime startDate, DateTime endDate);
        List<MenuModel> GetMenusCount();
        List<MenuModel> GetMenus();
    }
}
