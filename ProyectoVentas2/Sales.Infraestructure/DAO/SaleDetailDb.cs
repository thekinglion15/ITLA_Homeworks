using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class SaleDetailDb : DaoBase<SaleDetail>, ISaleDetailDb
    {
        private readonly SalesContext context;
        private readonly ILogger<SaleDetailDb> logger;
        private readonly IConfiguration configuration;

        public SaleDetailDb(SalesContext context, ILogger<SaleDetailDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<SaleDetail> GetAll()
        {
            return base.GetEntitiesWithFilters(bus => !bus.Deleted);
        }

        public List<SaleDetail> GetSaleDetailsById(int id)
        {
            return this.context.SaleDetails.Where(sal => sal.Id == id).ToList();
        }

        public override DataResult Save(SaleDetail entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(bus => bus.Name == entity.Name))
                    throw new SaleDetailException(this.configuration["SaleDetailMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleDetailMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(SaleDetail entity)
        {
            DataResult result = new DataResult();

            try
            {
                SaleDetail saleDetailToUpdate = base.GetById(entity.Id);

                saleDetailToUpdate.ModifyDate = entity.ModifyDate;
                saleDetailToUpdate.IdModifyUser = entity.IdModifyUser;
                saleDetailToUpdate.IdSale = entity.IdSale;
                saleDetailToUpdate.IdProduct = entity.IdProduct;
                saleDetailToUpdate.BrandProduct = entity.BrandProduct;
                saleDetailToUpdate.ProductCategory = entity.ProductCategory;
                saleDetailToUpdate.Quantity = entity.Quantity;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleDetailMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
