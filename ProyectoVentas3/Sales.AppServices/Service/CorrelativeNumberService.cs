using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class CorrelativeNumberService : ICorrelativeNumberService
    {
        private readonly ICorrelativeNumberDb correlativeNumberDb;
        private readonly ILogger<CorrelativeNumberService> logger;

        public CorrelativeNumberService(ICorrelativeNumberDb correlativeNumberDb, ILogger<CorrelativeNumberService> logger)
        {
            this.correlativeNumberDb = correlativeNumberDb;
            this.logger = logger;
        }

        public ServiceResult GetCorrelativeNumbers()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetCorrelativeNumbersByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetCorrelativeNumbersCount()
        {
            throw new NotImplementedException();
        }
    }
}
