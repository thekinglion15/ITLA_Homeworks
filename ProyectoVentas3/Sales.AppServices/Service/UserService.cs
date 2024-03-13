using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class UserService : IUserService
    {
        private readonly IUserDb userDb;
        private readonly ILogger<UserService> logger;

        public UserService(IUserDb userDb, ILogger<UserService> logger)
        {
            this.userDb = userDb;
            this.logger = logger;
        }

        public ServiceResult GetUsers()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetUsersByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetUsersCount()
        {
            throw new NotImplementedException();
        }
    }
}
