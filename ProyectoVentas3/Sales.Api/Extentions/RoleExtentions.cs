using Sales.Api.Models.Role;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class RoleExtentions
    {
        public static Role ConvertFromRoleCreateToRole(this RoleCreateModel model)
        {
            return new Role()
            {
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
