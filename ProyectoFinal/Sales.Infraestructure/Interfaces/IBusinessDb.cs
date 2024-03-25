using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IBusinessDb : IDaoBase<Business>
    {
        Task<int> AgregarNegocioAsync(string? p_DocNumber, string? p_Address, decimal? p_TaxPercent, string? p_CurrencySymbol, int? p_IdCreationUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerNegocios>> ObtenerNegociosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerNegocios>> ObtenerNegociosPorNombreAsync(string p_Name, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateNegocioAsync(int p_Id, string? p_DocNumber, string? p_Address, decimal? p_TaxPercent, string? p_CurrencySymbol, int? p_IdModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}