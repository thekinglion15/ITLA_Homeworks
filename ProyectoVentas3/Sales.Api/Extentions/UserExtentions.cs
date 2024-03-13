using Sales.Api.Models.User;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class UserExtentions
    {
        public static User ConvertFromUserCreateToUser(this UserCreateModel model)
        {
            return new User()
            {
                Key = model.Key,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
