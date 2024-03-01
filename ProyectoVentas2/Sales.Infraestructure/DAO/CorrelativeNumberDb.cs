using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class CorrelativeNumberDb : DaoBase<CorrelativeNumber>, ICorrelativeNumberDb
    {
        private readonly SalesContext context;
        private readonly ILogger<CorrelativeNumberDb> logger;
        private readonly IConfiguration configuration;

        public CorrelativeNumberDb(SalesContext context, ILogger<CorrelativeNumberDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<CorrelativeNumber> GetAll()
        {
            return base.GetEntitiesWithFilters(cnu => !cnu.Deleted);
        }

        public List<CorrelativeNumber> GetCorrelativeNumbersById(int id)
        {
            return this.context.CorrelativeNumbers.Where(cnu => cnu.Id == id).ToList();
        }

        public override DataResult Save(CorrelativeNumber entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(cnu => cnu.Name == entity.Name))
                    throw new CorrelativeNumberException(this.configuration["CorrelativeNumberMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["CorrelativeNumberMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(CorrelativeNumber entity)
        {
            DataResult result = new DataResult();

            try
            {
                CorrelativeNumber correlativeNumberToUpdate = base.GetById(entity.Id);

                correlativeNumberToUpdate.ModifyDate = entity.ModifyDate;
                correlativeNumberToUpdate.IdModifyUser = entity.IdModifyUser;
                correlativeNumberToUpdate.LastNumber = entity.LastNumber;
                correlativeNumberToUpdate.DigitsQuantity = entity.DigitsQuantity;
                correlativeNumberToUpdate.Management = entity.Management;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["CorrelativeNumberMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
