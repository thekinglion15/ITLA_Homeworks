using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ISaleDetailDb : IDaoBase<SaleDetail>
    {
        List<SaleDetailModel> GetSaleDetailsByDates(DateTime startDate, DateTime endDate);
        List<SaleDetailModel> GetSaleDetailsCount();
        List<SaleDetailModel> GetSaleDetails();
    }
}
