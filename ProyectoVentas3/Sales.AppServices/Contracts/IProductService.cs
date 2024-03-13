using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IProductService
    {
        ServiceResult GetProductsByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetProductsCount();
        ServiceResult GetProducts();
    }
}
