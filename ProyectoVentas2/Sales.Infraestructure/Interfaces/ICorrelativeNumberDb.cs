using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface ICorrelativeNumberDb : IDaoBase<CorrelativeNumber>
    {
        List<CorrelativeNumber> GetCorrelativeNumbersById(int id);
    }
}
