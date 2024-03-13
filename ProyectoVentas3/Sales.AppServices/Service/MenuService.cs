using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuDb menuDb;
        private readonly ILogger<MenuService> logger;

        public MenuService(IMenuDb menuDb, ILogger<MenuService> logger)
        {
            this.menuDb = menuDb;
            this.logger = logger;
        }

        public ServiceResult GetMenus()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetMenusByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetMenusCount()
        {
            throw new NotImplementedException();
        }
    }
}
