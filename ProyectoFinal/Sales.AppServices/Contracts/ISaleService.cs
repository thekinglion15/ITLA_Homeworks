using Sales.AppServices.Core;
using Sales.AppServices.Dtos;

namespace Sales.AppServices.Contracts
{
    public interface ISaleService
    {
        public Task<ServiceResult> GetSales();
        public Task<ServiceResult> GetSaleBySaleNumber(string saleNumber);
        public Task<ServiceResult> AddSale(SaleAddDto saleAddDto);
    }
}
