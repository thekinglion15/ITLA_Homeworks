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

        public List<ProductModel> GetProductByCategory(int categoryId)
        {
            List<ProductModel> products = new List<ProductModel>();

            try
            {
                products = (from prod in this.context.Products
                            join cat in this.context.Categories on prod.IdCategory equals cat.Id
                            where prod.Deleted == false && cat.Deleted == false
                            && prod.IdCategory == categoryId
                            select new ProductModel()
                            {
                                IdProduct = prod.Id,
                                BarCode = prod.BarCode,
                                Brand = prod.Brand,
                                Stock = prod.Stock,
                                IdCategory = prod.IdCategory
                            }).ToList();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error obteniendo los productos", ex.ToString());
            }

            return products;
        }

        public override List<Product> GetAll()
        {
            return base.GetEntitiesWithFilters(pro => !pro.Deleted);
        }

        public List<ProductModel> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProductsByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsById(int id)
        {
            return this.context.Products.Where(pro => pro.Id == id).ToList();
        }

        public List<ProductModel> GetProductsCount()
        {
            throw new NotImplementedException();
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
