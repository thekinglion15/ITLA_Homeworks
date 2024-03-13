using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDb categoryDb;
        private readonly ILogger<CategoryService> logger;

        public CategoryService(ICategoryDb businessDb, ILogger<CategoryService> logger)
        {
            this.categoryDb = businessDb;
            this.logger = logger;
        }

        public ServiceResult GetCategoriesCount()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.categoryDb.GetCategoriesCount();
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los categorias";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }
        public ServiceResult GetCategoriesByDates(DateTime startDate, DateTime endDate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.categoryDb.GetCategoriesByDates(startDate, endDate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los categorias";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult GetCategories()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var query = (from category in this.categoryDb.GetAll()
                             where category.Deleted == false
                             orderby category.RegisterDate descending
                             select new Models.CategoryModel(){}).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los categorias";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}
