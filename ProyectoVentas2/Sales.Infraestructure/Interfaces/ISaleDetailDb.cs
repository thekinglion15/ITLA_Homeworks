using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface ISaleDetailDb : IDaoBase<SaleDetail>
    {
        List<SaleDetail> GetSaleDetailsById(int id);
    }
}
