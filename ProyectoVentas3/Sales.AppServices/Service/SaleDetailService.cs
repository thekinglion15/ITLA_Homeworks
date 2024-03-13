using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class SaleDetailService : ISaleDetailService
    {
        private readonly ISaleDetailDb saleDetailDb;
        private readonly ILogger<SaleDetailService> logger;

        public SaleDetailService(ISaleDetailDb saleDetailDb, ILogger<SaleDetailService> logger)
        {
            this.saleDetailDb = saleDetailDb;
            this.logger = logger;
        }

        public ServiceResult GetSaleDetails()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetSaleDetailsByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetSaleDetailsCount()
        {
            throw new NotImplementedException();
        }
    }
}
