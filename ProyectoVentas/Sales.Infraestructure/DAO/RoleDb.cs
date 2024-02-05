using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class RoleDb : IRoleDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role GetById(int roleId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
