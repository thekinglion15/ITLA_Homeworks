using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface ISaleService
    {
        ServiceResult GetSalesByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetSalesCount();
        ServiceResult GetSales();
    }
}
