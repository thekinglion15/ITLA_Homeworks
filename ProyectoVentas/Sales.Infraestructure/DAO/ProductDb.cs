using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class ProductDb : IProductDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
