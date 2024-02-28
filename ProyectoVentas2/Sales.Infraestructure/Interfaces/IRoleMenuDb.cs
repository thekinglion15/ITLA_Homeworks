using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IRoleMenuDb : IDaoBase<RoleMenu>
    {
        List<RoleMenu> GetRoleMenusById(int id);
    }
}
