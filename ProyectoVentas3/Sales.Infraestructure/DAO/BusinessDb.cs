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
    public class BusinessDb : DaoBase<Business>, IBusinessDb
    {
        private readonly SalesContext context;
        private readonly ILogger<BusinessDb> logger;
        private readonly IConfiguration configuration;

        public BusinessDb(SalesContext context, ILogger<BusinessDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Business> GetAll()
        {
            return base.GetEntitiesWithFilters(bus => !bus.Deleted);
        }

        public List<BusinessModel> GetBusinessesCount()
        {
            throw new NotImplementedException();
        }

        public List<BusinessModel> GetBusinesses()
        {
            throw new NotImplementedException();
        }

        public List<BusinessModel> GetBusinessesByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Business> GetBusinessesById(int id)
        {
            return this.context.Businesses.Where(bus => bus.Id == id).ToList();
        }

        public override DataResult Save(Business entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(bus => bus.Name == entity.Name))
                    throw new BusinessException(this.configuration["BusinessMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch(Exception ex)
            {
                result.Message = this.configuration["BusinessMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Business entity)
        {
            DataResult result = new DataResult();

            try
            {
                Business businessToUpdate = base.GetById(entity.Id);

                businessToUpdate.ModifyDate = entity.ModifyDate;
                businessToUpdate.IdModifyUser = entity.IdModifyUser;
                businessToUpdate.DocNumber = entity.DocNumber;
                businessToUpdate.Address = entity.Address;
                businessToUpdate.TaxPercent = entity.TaxPercent;
                businessToUpdate.CurrencySymbol = entity.CurrencySymbol;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["BusinessMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
