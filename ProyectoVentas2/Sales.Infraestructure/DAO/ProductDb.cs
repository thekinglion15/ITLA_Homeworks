using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class ProductDb : DaoBase<Product>, IProductDb
    {
        private readonly SalesContext context;
        private readonly ILogger<ProductDb> logger;
        private readonly IConfiguration configuration;

        public ProductDb(SalesContext context, ILogger<ProductDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Product> GetAll()
        {
            return base.GetEntitiesWithFilters(pro => !pro.Deleted);
        }

        public List<Product> GetProductsById(int id)
        {
            return this.context.Products.Where(pro => pro.Id == id).ToList();
        }

        public override DataResult Save(Product entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(pro => pro.Name == entity.Name))
                    throw new ProductException(this.configuration["ProductMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["ProductMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Product entity)
        {
            DataResult result = new DataResult();

            try
            {
                Product productToUpdate = base.GetById(entity.Id);

                productToUpdate.ModifyDate = entity.ModifyDate;
                productToUpdate.IdModifyUser = entity.IdModifyUser;
                productToUpdate.BarCode = entity.BarCode;
                productToUpdate.Brand = entity.Brand;
                productToUpdate.IdCreationUser = entity.IdCreationUser;
                productToUpdate.Stock = entity.Stock;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["ProductMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
