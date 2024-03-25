using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ISaleDetailDb : IDaoBase<SaleDetail>
    {
        Task<int> AgregarDetalleAsync(int? p_IdSale, int? p_IdProduct, string? p_BrandProduct, string? p_ProductCategory, int? p_Quantity, int? p_IdCreationUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerVentaDetalle>> ObtenerDetalleAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerVentaDetalle>> ObtenerDetallePorVentaAsync(int p_IdSale, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateDetalleAsync(int p_Id, int? p_IdSale, int? p_IdProduct, string? p_BrandProduct, string? p_ProductCategory, int? p_Quantity, int? p_IdModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}