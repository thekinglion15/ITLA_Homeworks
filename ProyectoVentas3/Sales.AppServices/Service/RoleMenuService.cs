using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class RoleMenuService : IRoleMenuService
    {
        private readonly IRoleMenuDb roleMenuDb;
        private readonly ILogger<RoleMenuService> logger;

        public RoleMenuService(IRoleMenuDb roleMenuDb, ILogger<RoleMenuService> logger)
        {
            this.roleMenuDb = roleMenuDb;
            this.logger = logger;
        }

        public ServiceResult GetRoleMenus()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetRoleMenusByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetRoleMenusCount()
        {
            throw new NotImplementedException();
        }
    }
}
