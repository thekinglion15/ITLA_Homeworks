using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface ICorrelativeNumberDb : IDaoBase<CorrelativeNumber>
    {
        List<CorrelativeNumberModel> GetCorrelativeNumbersByDates(DateTime startDate, DateTime endDate);
        List<CorrelativeNumberModel> GetCorrelativeNumbersCount();
        List<CorrelativeNumberModel> GetCorrelativeNumbers();
    }
}
