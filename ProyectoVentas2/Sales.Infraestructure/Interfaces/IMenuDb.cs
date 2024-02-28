using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IMenuDb : IDaoBase<Menu>
    {
        List<Menu> GetMenusById(int id);
    }
}
