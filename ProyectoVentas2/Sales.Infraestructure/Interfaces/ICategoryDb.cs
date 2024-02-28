﻿using Sales.Domain.Entities;
using Sales.Infraestructure.Core;

namespace Sales.Infraestructure.Interfaces
{
    public interface ICategoryDb : IDaoBase<Category>
    {
        List<Category> GetCategoriesById(int id);
    }
}
