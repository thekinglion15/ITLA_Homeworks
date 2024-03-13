using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationDb configurationDb;
        private readonly ILogger<ConfigurationService> logger;

        public ConfigurationService(IConfigurationDb configurationDb, ILogger<ConfigurationService> logger)
        {
            this.configurationDb = configurationDb;
            this.logger = logger;
        }

        public ServiceResult GetConfigurations()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetConfigurationsByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetConfigurationsCount()
        {
            throw new NotImplementedException();
        }
    }
}
