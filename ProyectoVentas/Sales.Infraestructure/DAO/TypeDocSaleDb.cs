using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class TypeDocSaleDb : ITypeDocSaleDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<TypeDocSale> GetAll()
        {
            throw new NotImplementedException();
        }

        public TypeDocSale GetById(int typeDocSaleId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(TypeDocSale entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeDocSale entity)
        {
            throw new NotImplementedException();
        }
    }
}
