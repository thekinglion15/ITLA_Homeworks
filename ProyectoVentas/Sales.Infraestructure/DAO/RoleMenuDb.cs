using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class RoleMenuDb : IRoleMenuDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<RoleMenu> GetAll()
        {
            throw new NotImplementedException();
        }

        public RoleMenu GetById(int roleMenuId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(RoleMenu entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleMenu entity)
        {
            throw new NotImplementedException();
        }
    }
}
