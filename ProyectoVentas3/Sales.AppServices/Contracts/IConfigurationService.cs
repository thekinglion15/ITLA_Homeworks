using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface IConfigurationService
    {
        ServiceResult GetConfigurationsByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetConfigurationsCount();
        ServiceResult GetConfigurations();
    }
}
