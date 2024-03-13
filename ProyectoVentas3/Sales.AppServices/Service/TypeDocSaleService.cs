using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class TypeDocSaleService : ITypeDocSaleService
    {
        private readonly ITypeDocSaleDb typeDocSaleDb;
        private readonly ILogger<TypeDocSaleService> logger;

        public TypeDocSaleService(ITypeDocSaleDb typeDocSaleDb, ILogger<TypeDocSaleService> logger)
        {
            this.typeDocSaleDb = typeDocSaleDb;
            this.logger = logger;
        }

        public ServiceResult GetTypeDocSales()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetTypeDocSalesByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetTypeDocSalesCount()
        {
            throw new NotImplementedException();
        }
    }
}
