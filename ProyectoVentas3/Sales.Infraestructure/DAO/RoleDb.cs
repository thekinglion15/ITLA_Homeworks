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
    public class RoleDb : DaoBase<Role>, IRoleDb
    {
        private readonly SalesContext context;
        private readonly ILogger<RoleDb> logger;
        private readonly IConfiguration configuration;

        public RoleDb(SalesContext context, ILogger<RoleDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Role> GetAll()
        {
            return base.GetEntitiesWithFilters(rol => !rol.Deleted);
        }

        public List<RoleModel> GetRoles()
        {
            throw new NotImplementedException();
        }

        public List<RoleModel> GetRolesByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRolesById(int id)
        {
            return this.context.Roles.Where(rol => rol.Id == id).ToList();
        }

        public List<RoleModel> GetRolesCount()
        {
            throw new NotImplementedException();
        }

        public override DataResult Save(Role entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(rol => rol.Name == entity.Name))
                    throw new RoleException(this.configuration["RoleMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["RoleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Role entity)
        {
            DataResult result = new DataResult();

            try
            {
                Role roleToUpdate = base.GetById(entity.Id);

                roleToUpdate.ModifyDate = entity.ModifyDate;
                roleToUpdate.IdModifyUser = entity.IdModifyUser;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["RoleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
