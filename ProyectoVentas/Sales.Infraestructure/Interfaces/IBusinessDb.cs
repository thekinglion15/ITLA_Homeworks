using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IBusinessDb : IDaoBase<Business>
    {
    }
}
