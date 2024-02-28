using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IRoleDb : IDaoBase<Role>
    {
        List<Role> GetRolesById(int id);
    }
}
