using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface ISaleDetailService
    {
        ServiceResult GetSaleDetailsByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetSaleDetailsCount();
        ServiceResult GetSaleDetails();
    }
}
