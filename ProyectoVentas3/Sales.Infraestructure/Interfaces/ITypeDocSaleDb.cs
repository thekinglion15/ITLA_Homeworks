using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ITypeDocSaleDb : IDaoBase<TypeDocSale>
    {
        List<TypeDocSaleModel> GetTypeDocSalesByDates(DateTime startDate, DateTime endDate);
        List<TypeDocSaleModel> GetTypeDocSalesCount();
        List<TypeDocSaleModel> GetTypeDocSales();
    }
}
