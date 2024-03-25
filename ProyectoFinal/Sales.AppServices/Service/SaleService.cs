using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.AppServices.Dtos;
using Sales.AppServices.Models;
using Sales.Infraestructure.Core;
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

        public async Task<ServiceResult> AddSale(SaleAddDto saleAddDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                OutputParameter<string> resp = new OutputParameter<string>();

                await this.saleDb.AgregarVentaAsync(
                    saleAddDto.SaleNumber,
                    saleAddDto.IdTypeDocSale,
                    saleAddDto.IdUser,
                    saleAddDto.ClientDoc,
                    saleAddDto.NameClient,
                    saleAddDto.Subtotal,
                    saleAddDto.TaxTotal,
                    saleAddDto.IdCreationUser,
                    resp);

                if (resp.Value.Equals("Ok"))
                    result.Message = "Venta creado correctamente.";
                else
                {
                    result.Message = resp.Value;
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error agregando la venta {ex.Message}.";
            }

            return result;
        }

        public async Task<ServiceResult> GetSaleBySaleNumber(string saleNumber)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (await this.saleDb.ObtenerVentasPorNumeroVentaAsync(saleNumber))
                                                    .Select(sale => new SaleModel()
                                                    {
                                                        SaleNumber = sale.SaleNumber,
                                                        IdTypeDocSale = sale.IdTypeDocSale,
                                                        IdUser = sale.IdUser,
                                                        ClientDoc = sale.ClientDoc,
                                                        NameClient = sale.NameClient,
                                                        Subtotal = sale.Subtotal,
                                                        TaxTotal = sale.TaxTotal
                                                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo la venta {ex.Message}.";
            }

            return result;
        }

        public async Task<ServiceResult> GetSales()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                //LINQ
                var query = (from sale in await this.saleDb.GetAll()
                             where sale.Deleted == false
                             orderby sale.RegisterDate descending
                             select new SaleModel()
                             {
                                 SaleNumber = sale.SaleNumber,
                                 IdTypeDocSale = sale.IdTypeDocSale,
                                 IdUser = sale.IdUser,
                                 ClientDoc = sale.ClientDoc,
                                 NameClient = sale.NameClient,
                                 Subtotal = sale.Subtotal,
                                 TaxTotal = sale.TaxTotal
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
