using Sales.Api.Models.Menu;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class MenuExtentions
    {
        public static Menu ConvertFromMenuCreateToMenu(this MenuCreateModel model)
        {
            return new Menu()
            {
                IdMenuFather = model.IdMenuFather,
                Icon = model.Icon,
                Driver = model.Driver,
                ActionPage = model.ActionPage,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
