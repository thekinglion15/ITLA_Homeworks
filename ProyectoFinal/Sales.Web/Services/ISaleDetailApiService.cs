using Sales.Web.Models;
using Sales.Web.Models.Results;

namespace Sales.Web.Services
{
    public interface ISaleDetailApiService
    {
        Task<GetSaleDetailResult<List<SaleDetailResponseModel>>> GetSaleDetails();
        Task<GetSaleDetailResult<SaleDetailResponseModel>> GetDetailBySale(SaleDetailSearch saleDetailSearch);
        Task<ServiceResult> SaveSaleDetail(SaleDetailModel createModel);
        Task<ServiceResult> UpdateSaleDetail(SaleDetailModel UpateModel);
    }
}
