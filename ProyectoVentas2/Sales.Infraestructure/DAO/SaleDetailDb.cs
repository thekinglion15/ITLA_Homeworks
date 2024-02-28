using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class SaleDetailDb : ISaleDetailDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<SaleDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public SaleDetail GetById(int saleDetailId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(SaleDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SaleDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
