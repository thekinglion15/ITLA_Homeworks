using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ISaleDb : IDaoBase<Sale>
    {
        List<SaleModel> GetSalesByDates(DateTime startDate, DateTime endDate);
        List<SaleModel> GetSalesCount();
        List<SaleModel> GetSales();
    }
}
