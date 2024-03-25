using Sales.Web.Models;
using Sales.Web.Models.Results;

namespace Sales.Web.Services
{
    public interface IBusinessApiService
    {
        Task<GetBusinessResult<List<BusinessResponseModel>>> GetBusinesses();
        Task<GetBusinessResult<BusinessResponseModel>> GetBusinessByName(BusinessSearch businessSearch);
        Task<ServiceResult> SaveBusiness(BusinessModel createModel);
        Task<ServiceResult> UpdateBusiness(BusinessModel UpateModel);
    }
}
