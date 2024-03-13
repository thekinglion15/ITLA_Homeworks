using Sales.Api.Models.RoleMenu;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class RoleMenuExtentions
    {
        public static RoleMenu ConvertFromRoleMenuCreateToRoleMenu(this RoleMenuCreateModel model)
        {
            return new RoleMenu()
            {
                IdMenu = model.IdMenu,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
