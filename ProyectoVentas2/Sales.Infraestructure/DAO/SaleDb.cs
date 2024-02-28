using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class SaleDb : ISaleDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public Sale GetById(int saleId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Sale entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Sale entity)
        {
            throw new NotImplementedException();
        }
    }
}
