using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ISaleDb : IDaoBase<Sale>
    {
        Task<int> AgregarVentaAsync(string? p_SaleNumber, int? p_IdTypeDocSale, int? p_IdUser, string? p_ClientDoc, string? p_NameClient, decimal? p_Subtotal, decimal? p_TaxTotal, int? p_IdCreationUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerVentas>> ObtenerVentasAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerVentas>> ObtenerVentasPorNumeroVentaAsync(string p_SaleNumber, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateVentaAsync(int p_Id, string? p_SaleNumber, int? p_IdTypeDocSale, int? p_IdUser, string? p_ClientDoc, string? p_NameClient, decimal? p_Subtotal, decimal? p_TaxTotal, int? p_IdModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}