using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IRoleDb : IDaoBase<Role>
    {
        List<RoleModel> GetRolesByDates(DateTime startDate, DateTime endDate);
        List<RoleModel> GetRolesCount();
        List<RoleModel> GetRoles();
    }
}
