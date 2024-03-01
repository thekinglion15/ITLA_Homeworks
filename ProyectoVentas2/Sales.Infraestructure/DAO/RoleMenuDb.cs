using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class RoleMenuDb : DaoBase<RoleMenu>, IRoleMenuDb
    {
        private readonly SalesContext context;
        private readonly ILogger<RoleMenuDb> logger;
        private readonly IConfiguration configuration;

        public RoleMenuDb(SalesContext context, ILogger<RoleMenuDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<RoleMenu> GetAll()
        {
            return base.GetEntitiesWithFilters(rol => !rol.Deleted);
        }

        public List<RoleMenu> GetRoleMenusById(int id)
        {
            return this.context.RoleMenus.Where(rol => rol.Id == id).ToList();
        }

        public override DataResult Save(RoleMenu entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(rol => rol.Name == entity.Name))
                    throw new RoleMenuException(this.configuration["RoleMenuMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["RoleMenuMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(RoleMenu entity)
        {
            DataResult result = new DataResult();

            try
            {
                RoleMenu roleMenuToUpdate = base.GetById(entity.Id);

                roleMenuToUpdate.ModifyDate = entity.ModifyDate;
                roleMenuToUpdate.IdModifyUser = entity.IdModifyUser;
                roleMenuToUpdate.IdMenu = entity.IdMenu;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["RoleMenuMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
