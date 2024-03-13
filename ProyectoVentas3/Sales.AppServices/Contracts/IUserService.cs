using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IUserService
    {
        ServiceResult GetUsersByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetUsersCount();
        ServiceResult GetUsers();
    }
}
