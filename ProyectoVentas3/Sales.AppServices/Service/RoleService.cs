using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleDb roleDb;
        private readonly ILogger<RoleService> logger;

        public RoleService(IRoleDb roleDb, ILogger<RoleService> logger)
        {
            this.roleDb = roleDb;
            this.logger = logger;
        }

        public ServiceResult GetRoles()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetRolesByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetRolesCount()
        {
            throw new NotImplementedException();
        }
    }
}
