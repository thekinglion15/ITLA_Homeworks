using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IRoleService
    {
        ServiceResult GetRolesByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetRolesCount();
        ServiceResult GetRoles();
    }
}
