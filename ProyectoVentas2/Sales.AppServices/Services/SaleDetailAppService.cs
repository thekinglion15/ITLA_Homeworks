using Sales.AppServices.Core;
using Sales.Infraestructure.Exceptions;

namespace Sales.AppServices.Services
{
    public class SaleDetailAppService
    {
        public ServiceResult Save()
        {
            ServiceResult result = new ServiceResult();

            try
            {

            }
            catch (BusinessException bex)
            {
                result.Message = bex.Message;
                result.Success = false;
            }

            return result;
        }
    }
}
