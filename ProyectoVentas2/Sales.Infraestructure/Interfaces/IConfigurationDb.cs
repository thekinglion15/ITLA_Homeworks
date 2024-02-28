﻿using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface IConfigurationDb : IDaoBase<Configuration>
    {
        List<Configuration> GetConfigurationsById(int id);
    }
}