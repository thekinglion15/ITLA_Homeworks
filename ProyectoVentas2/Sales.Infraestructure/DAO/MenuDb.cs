using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class MenuDb : IMenuDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetAll()
        {
            throw new NotImplementedException();
        }

        public Menu GetById(int menuId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Menu entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
