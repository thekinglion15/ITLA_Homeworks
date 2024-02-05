using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class BusinessDb : IBusinessDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Business> GetAll()
        {
            throw new NotImplementedException();
        }

        public Business GetById(int businessId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Business entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Business entity)
        {
            throw new NotImplementedException();
        }
    }
}
