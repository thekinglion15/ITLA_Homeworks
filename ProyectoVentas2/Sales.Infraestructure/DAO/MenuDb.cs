using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Interfaces;

namespace Sales.Infraestructure.DAO
{
    public class MenuDb : DaoBase<Menu>, IMenuDb
    {
        private readonly SalesContext context;
        private readonly ILogger<MenuDb> logger;
        private readonly IConfiguration configuration;

        public MenuDb(SalesContext context, ILogger<MenuDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public override List<Menu> GetAll()
        {
            return base.GetEntitiesWithFilters(men => !men.Deleted);
        }

        public List<Menu> GetMenusById(int id)
        {
            return this.context.Menus.Where(men => men.Id == id).ToList();
        }

        public override DataResult Save(Menu entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(men => men.Name == entity.Name))
                    throw new MenuException(this.configuration["MenuMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["MenuMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override DataResult Update(Menu entity)
        {
            DataResult result = new DataResult();

            try
            {
                Menu menuToUpdate = base.GetById(entity.Id);

                menuToUpdate.ModifyDate = entity.ModifyDate;
                menuToUpdate.IdModifyUser = entity.IdModifyUser;
                menuToUpdate.IdMenuFather = entity.IdMenuFather;
                menuToUpdate.Icon = entity.Icon;
                menuToUpdate.Driver = entity.Driver;
                menuToUpdate.ActionPage = entity.ActionPage;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["MenuMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return base.Update(entity);
        }
    }
}
