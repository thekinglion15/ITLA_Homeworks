using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessDb businessDb;
        private readonly ILogger<BusinessService> logger;

        public BusinessService(IBusinessDb businessDb, ILogger<BusinessService> logger)
        {
            this.businessDb = businessDb;
            this.logger = logger;
        }

        public ServiceResult GetBusinessesCount()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.businessDb.GetBusinessesCount();
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }
        public ServiceResult GetBusinessesByDates(DateTime startDate, DateTime endDate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.businessDb.GetBusinessesByDates(startDate, endDate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult GetBusinesses()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                //LINQ
                var query = (from business in this.businessDb.GetAll()
                             where business.Deleted == false
                             orderby business.RegisterDate descending
                             select new Models.BusinessModel()
                             {
                                 DocNumber = business.DocNumber,
                                 Address = business.Address,
                                 TaxPercent = business.TaxPercent,
                                 CurrencySymbol = business.CurrencySymbol
                             }).ToList();

                //Lambda
                //var query2 = this.businessDb.GetEntitiesWithFilters(bd => bd.Deleted == false)
                //                            .Select(bd => new Models.BusinessModel()
                //                            {
                //                                DocNumber = business.DocNumber,
                //                                Address = business.Address,
                //                                TaxPercent = business.TaxPercent,
                //                                CurrencySymbol = business.CurrencySymbol
                //                            }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}
