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
    public class UserDb : DaoBase<User>, IUserDb
    {
        private readonly SalesContext context;
        private readonly ILogger<UserDb> logger;
        private readonly IConfiguration configuration;

        public UserDb(SalesContext context, ILogger<UserDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<User> GetAll()
        {
            return base.GetEntitiesWithFilters(use => !use.Deleted);
        }

        public List<UserModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetUsersByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersById(int id)
        {
            return this.context.Users.Where(use => use.Id == id).ToList();
        }

        public List<UserModel> GetUsersCount()
        {
            throw new NotImplementedException();
        }

        public override DataResult Save(User entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(use => use.Name == entity.Name))
                    throw new UserException(this.configuration["UserMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["UserMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(User entity)
        {
            DataResult result = new DataResult();

            try
            {
                User userToUpdate = base.GetById(entity.Id);

                userToUpdate.ModifyDate = entity.ModifyDate;
                userToUpdate.IdModifyUser = entity.IdModifyUser;
                userToUpdate.Key = entity.Key;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["UserMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
