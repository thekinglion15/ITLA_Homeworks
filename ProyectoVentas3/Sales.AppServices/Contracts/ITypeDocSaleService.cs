using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface ITypeDocSaleService
    {
        ServiceResult GetTypeDocSalesByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetTypeDocSalesCount();
        ServiceResult GetTypeDocSales();
    }
}
