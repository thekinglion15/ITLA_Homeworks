using Sales.AppServices.Core;
using Sales.AppServices.Dtos;

namespace Sales.AppServices.Contracts
{
    public interface IBusinessService
    {
        public Task<ServiceResult> GetBusinesses();
        public Task<ServiceResult> GetBusinessByName(string name);
        public Task<ServiceResult> AddBusiness(BusinessAddDto businessAddDto);
        
    }
}
