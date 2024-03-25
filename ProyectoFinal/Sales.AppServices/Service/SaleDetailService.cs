using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.AppServices.Dtos;
using Sales.AppServices.Models;
using Sales.Infraestructure.Core;
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

        public async Task<ServiceResult> AddSaleDetail(SaleDetailAddDto saleDetailAddDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                OutputParameter<string> resp = new OutputParameter<string>();

                await this.saleDetailDb.AgregarDetalleAsync(
                    saleDetailAddDto.IdSale,
                    saleDetailAddDto.IdProduct,
                    saleDetailAddDto.BrandProduct,
                    saleDetailAddDto.ProductCategory,
                    saleDetailAddDto.Quantity,
                    saleDetailAddDto.IdCreationUser,
                    resp);

                if (resp.Value.Equals("Ok"))
                    result.Message = "Detalle de venta creado correctamente.";
                else
                {
                    result.Message = resp.Value;
                    result.Success = false;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error agregando el detalle de venta {ex.Message}.";
            }

            return result;
        }

        public async Task<ServiceResult> GetSaleDetailBySale(int idSale)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (await this.saleDetailDb.ObtenerDetallePorVentaAsync(idSale))
                                                    .Select(det => new SaleDetailModel()
                                                    {
                                                        IdSale = det.IdSale,
                                                        IdProduct = det.IdProduct,
                                                        BrandProduct = det.BrandProduct,
                                                        ProductCategory = det.ProductCategory,
                                                        Quantity = det.Quantity
                                                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el detalle de venta {ex.Message}.";
            }

            return result;
        }

        public async Task<ServiceResult> GetSaleDetails()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                //LINQ
                var query = (from saleDetail in await this.saleDetailDb.GetAll()
                             where saleDetail.Deleted == false
                             orderby saleDetail.RegisterDate descending
                             select new SaleDetailModel()
                             {
                                 IdSale = saleDetail.IdSale,
                                 IdProduct = saleDetail.IdProduct,
                                 BrandProduct = saleDetail.BrandProduct,
                                 ProductCategory = saleDetail.ProductCategory,
                                 Quantity = saleDetail.Quantity
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
