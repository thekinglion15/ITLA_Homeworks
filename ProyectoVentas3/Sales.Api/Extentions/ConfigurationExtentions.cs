using Sales.Api.Models.Configuration;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class ConfigurationExtentions
    {
        public static Configuration ConvertFromConfigurationCreateToConfiguration(this ConfigurationCreateModel model)
        {
            return new Configuration()
            {
                Resource = model.Resource,
                Property = model.Property,
                Value = model.Value,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
