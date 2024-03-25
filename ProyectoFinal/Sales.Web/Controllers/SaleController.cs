using Microsoft.AspNetCore.Mvc;
using Sales.Web.Models;
using Sales.Web.Services;

namespace Sales.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleApiService saleApi;

        public SaleController(ISaleApiService saleApi)
        {
            this.saleApi = saleApi;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.saleApi.GetSales();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var sales = result.data;

            return View(sales);
        }

        public async Task<IActionResult> Edit(SaleSearch search)
        {
            var result = await this.saleApi.GetSaleBySaleNumber(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var sales = result.data;

            return View(sales);
        }

        public async Task<IActionResult> Details(SaleSearch search)
        {
            var result = await this.saleApi.GetSaleBySaleNumber(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var sales = result.data;

            return View(sales);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleModel saleModel)
        {
            saleModel.ChangeDate = DateTime.Now;
            saleModel.UserId = 1;
            var result = await this.saleApi.SaveSale(saleModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
