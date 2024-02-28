using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class CorrelativeNumberDb : ICorrelativeNumberDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<CorrelativeNumber> GetAll()
        {
            throw new NotImplementedException();
        }

        public CorrelativeNumber GetById(int correlativeNumberId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(CorrelativeNumber entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CorrelativeNumber entity)
        {
            throw new NotImplementedException();
        }
    }
}
