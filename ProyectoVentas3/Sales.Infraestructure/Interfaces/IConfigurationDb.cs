using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IConfigurationDb : IDaoBase<Configuration>
    {
        List<ConfigurationModel> GetConfigurationsByDates(DateTime startDate, DateTime endDate);
        List<ConfigurationModel> GetConfigurationsCount();
        List<ConfigurationModel> GetConfigurations();
    }
}
