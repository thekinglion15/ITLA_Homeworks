using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class SaleDb : DaoBase<Sale>, ISaleDb
    {
        private readonly SalesContext context;
        private readonly ILogger<SaleDb> logger;
        private readonly IConfiguration configuration;

        public SaleDb(SalesContext context, ILogger<SaleDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Sale> GetAll()
        {
            return base.GetEntitiesWithFilters(sal => !sal.Deleted);
        }

        public List<Sale> GetSalesById(int id)
        {
            return this.context.Sales.Where(sal => sal.Id == id).ToList();
        }

        public override DataResult Save(Sale entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(sal => sal.Name == entity.Name))
                    throw new SaleException(this.configuration["SaleMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Sale entity)
        {
            DataResult result = new DataResult();

            try
            {
                Sale saleToUpdate = base.GetById(entity.Id);

                saleToUpdate.ModifyDate = entity.ModifyDate;
                saleToUpdate.IdModifyUser = entity.IdModifyUser;
                saleToUpdate.SaleNumber = entity.SaleNumber;
                saleToUpdate.IdTypeDocSale = entity.IdTypeDocSale;
                saleToUpdate.IdUser = entity.IdUser;
                saleToUpdate.ClientDoc = entity.ClientDoc;
                saleToUpdate.NameClient = entity.NameClient;
                saleToUpdate.Subtotal = entity.Subtotal;
                saleToUpdate.TaxTotal = entity.TaxTotal;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
