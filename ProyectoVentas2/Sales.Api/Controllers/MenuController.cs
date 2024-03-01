using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Menu;
using Sales.Infraestructure.DAO;
using System;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuDb menuDb;

        public MenuController(IMenuDb menuDb)
        {
            this.menuDb = menuDb;
        }

        [HttpGet("GetMenus")]
        public IActionResult GetMenus()
        {
            var menus = this.menuDb.GetAll();

            return Ok(menus);
        }

        [HttpPost("Save")]
        public IActionResult Save(MenuCreateModel createModel)
        {
            var result = this.menuDb.Save(new Menu()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                IdMenuFather = createModel.IdMenuFather,
                Icon = createModel.Icon,
                Driver = createModel.Driver,
                ActionPage = createModel.ActionPage
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(MenuCreateModel updateMenu)
        {
            var result = this.menuDb.Save(new Menu()
            {
                ModifyDate = updateMenu.ModifyDate,
                IdCreationUser = updateMenu.IdCreationUser,
                IdMenuFather = updateMenu.IdMenuFather,
                Icon = updateMenu.Icon,
                Driver = updateMenu.Driver,
                ActionPage = updateMenu.ActionPage
            });

            return Ok(result);
        }
    }
}
