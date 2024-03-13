using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.DAO
{
    public class CategoryDb : DaoBase<Category>, ICategoryDb
    {
        private readonly SalesContext context;
        private readonly ILogger<CategoryDb> logger;
        private readonly IConfiguration configuration;

        public CategoryDb(SalesContext context, ILogger<CategoryDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Category> GetAll()
        {
            return base.GetEntitiesWithFilters(cat => !cat.Deleted);
        }

        public List<CategoryModel> GetCategories()
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> GetCategoriesByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategoriesById(int id)
        {
            return this.context.Categories.Where(bus => bus.Id == id).ToList();
        }

        public List<CategoryModel> GetCategoriesCount()
        {
            throw new NotImplementedException();
        }

        public override DataResult Save(Category entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(cat => cat.Name == entity.Name))
                    throw new CategoryException(this.configuration["CategoryMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["CategoryMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Category entity)
        {
            DataResult result = new DataResult();

            try
            {
                Category categoryToUpdate = base.GetById(entity.Id);

                categoryToUpdate.ModifyDate = entity.ModifyDate;
                categoryToUpdate.IdModifyUser = entity.IdModifyUser;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["CategoryMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
