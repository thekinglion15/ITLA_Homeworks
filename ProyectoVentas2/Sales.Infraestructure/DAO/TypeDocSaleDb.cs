using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class TypeDocSaleDb : DaoBase<TypeDocSale>, ITypeDocSaleDb
    {
        private readonly SalesContext context;
        private readonly ILogger<TypeDocSaleDb> logger;
        private readonly IConfiguration configuration;

        public TypeDocSaleDb(SalesContext context, ILogger<TypeDocSaleDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<TypeDocSale> GetAll()
        {
            return base.GetEntitiesWithFilters(typ => !typ.Deleted);
        }

        public List<TypeDocSale> GetTypeDocSalesById(int id)
        {
            return this.context.TypeDocSales.Where(typ => typ.Id == id).ToList();
        }

        public override DataResult Save(TypeDocSale entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(typ => typ.Name == entity.Name))
                    throw new TypeDocSaleException(this.configuration["TypeDocSaleMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["TypeDocSaleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(TypeDocSale entity)
        {
            DataResult result = new DataResult();

            try
            {
                TypeDocSale typeDocSaleToUpdate = base.GetById(entity.Id);

                typeDocSaleToUpdate.ModifyDate = entity.ModifyDate;
                typeDocSaleToUpdate.IdModifyUser = entity.IdModifyUser;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["TypeDocSaleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
