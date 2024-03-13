using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleDb saleDb;
        private readonly ILogger<SaleService> logger;

        public SaleService(ISaleDb saleDb, ILogger<SaleService> logger)
        {
            this.saleDb = saleDb;
            this.logger = logger;
        }

        public ServiceResult GetSales()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetSalesByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetSalesCount()
        {
            throw new NotImplementedException();
        }
    }
}
