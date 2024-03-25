using Sales.Web.Models;
using Sales.Web.Models.Results;

namespace Sales.Web.Services
{
    public interface ISaleApiService
    {
        Task<GetSaleResult<List<SaleResponseModel>>> GetSales();
        Task<GetSaleResult<SaleResponseModel>> GetSaleBySaleNumber(SaleSearch saleSearch);
        Task<ServiceResult> SaveSale(SaleModel createModel);
        Task<ServiceResult> UpdateSale(SaleModel UpateModel);
    }
}
