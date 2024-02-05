using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class ConfigurationDb : IConfigurationDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Configuration> GetAll()
        {
            throw new NotImplementedException();
        }

        public Configuration GetById(int configurationId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Configuration entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Configuration entity)
        {
            throw new NotImplementedException();
        }
    }
}
