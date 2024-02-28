using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface ITypeDocSaleDb : IDaoBase<TypeDocSale>
    {
        List<TypeDocSale> GetTypeDocSalesById(int id);
    }
}
