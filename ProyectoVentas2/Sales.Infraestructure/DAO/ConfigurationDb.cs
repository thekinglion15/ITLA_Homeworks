using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class ConfigurationDb : DaoBase<Configuration>, IConfigurationDb
    {
        private readonly SalesContext context;
        private readonly ILogger<ConfigurationDb> logger;
        private readonly IConfiguration configuration;

        public ConfigurationDb(SalesContext context, ILogger<ConfigurationDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Configuration> GetAll()
        {
            return base.GetEntitiesWithFilters(con => !con.Deleted);
        }

        public List<Configuration> GetConfigurationsById(int id)
        {
            return this.context.Configurations.Where(con => con.Id == id).ToList();
        }

        public override DataResult Save(Configuration entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(bus => bus.Name == entity.Name))
                    throw new ConfigurationException(this.configuration["ConfigurationMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["ConfigurationMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Configuration entity)
        {
            DataResult result = new DataResult();

            try
            {
                Configuration configurationToUpdate = base.GetById(entity.Id);

                configurationToUpdate.ModifyDate = entity.ModifyDate;
                configurationToUpdate.IdModifyUser = entity.IdModifyUser;
                configurationToUpdate.Resource = entity.Resource;
                configurationToUpdate.Property = entity.Property;
                configurationToUpdate.Value = entity.Value;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["ConfigurationMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
