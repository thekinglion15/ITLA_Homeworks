using Sales.AppServices.Core;
using Sales.AppServices.Dtos;

namespace Sales.AppServices.Contracts
{
    public interface ISaleDetailService
    {
        public Task<ServiceResult> GetSaleDetails();
        public Task<ServiceResult> GetSaleDetailBySale(int idSale);
        public Task<ServiceResult> AddSaleDetail(SaleDetailAddDto saleDetailAddDto);
    }
}
