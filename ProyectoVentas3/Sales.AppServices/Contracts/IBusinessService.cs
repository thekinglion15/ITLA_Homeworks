using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IBusinessService
    {
        ServiceResult GetBusinessesByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetBusinessesCount();
        ServiceResult GetBusinesses();
    }
}
