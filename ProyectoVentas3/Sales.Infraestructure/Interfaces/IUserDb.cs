using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IUserDb : IDaoBase<User>
    {
        List<UserModel> GetUsersByDates(DateTime startDate, DateTime endDate);
        List<UserModel> GetUsersCount();
        List<UserModel> GetUsers();
    }
}
