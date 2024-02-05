using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IProductDb : IDaoBase<Product>
    {
    }
}
