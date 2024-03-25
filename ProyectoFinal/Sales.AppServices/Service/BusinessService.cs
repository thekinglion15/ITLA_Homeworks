using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.AppServices.Dtos;
using Sales.AppServices.Models;
using Sales.Infraestructure.Core;
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

        public async Task<ServiceResult> AddBusiness(BusinessAddDto businessAddDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                OutputParameter<string> resp = new OutputParameter<string>();

                await this.businessDb.AgregarNegocioAsync(
                    businessAddDto.DocNumber,
                    businessAddDto.Address,
                    businessAddDto.TaxPercent,
                    businessAddDto.CurrencySymbol,
                    businessAddDto.IdCreationUser,
                    resp);

                if (resp.Value.Equals("Ok"))
                    result.Message = "Negocio creado correctamente.";
                else
                {
                    result.Message = resp.Value;
                    result.Success = false;
                }
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = $"Error agregando el negocio {ex.Message}.";
            }

            return result;
        }

        public async Task<ServiceResult> GetBusinessByName(string name)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (await this.businessDb.ObtenerNegociosPorNombreAsync(name))
                                                    .Select(bus => new BusinessModel()
                                                    {
                                                        DocNumber = bus.DocNumber,
                                                        Address = bus.Address,
                                                        TaxPercent = bus.TaxPercent,
                                                        CurrencySymbol = bus.CurrencySymbol
                                                    }).FirstOrDefault();           
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el negocio {ex.Message}.";
            }

            return result;
        }

        public async Task<ServiceResult> GetBusinesses()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                //LINQ
                var query = (from business in await this.businessDb.GetAll()
                             where business.Deleted == false
                             orderby business.RegisterDate descending
                             select new Models.BusinessModel()
                             {
                                 DocNumber = business.DocNumber,
                                 Address = business.Address,
                                 TaxPercent = business.TaxPercent,
                                 CurrencySymbol = business.CurrencySymbol
                             }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }
    }
}