using Microsoft.AspNetCore.Mvc;
using Sales.Web.Models;
using Sales.Web.Services;

namespace Sales.Web.Controllers
{
    public class SaleDetailController : Controller
    {
        private readonly ISaleDetailApiService saleDetailApi;

        public SaleDetailController(ISaleDetailApiService saleDetailApi)
        {
            this.saleDetailApi = saleDetailApi;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.saleDetailApi.GetSaleDetails();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var sales = result.data;

            return View(sales);
        }

        public async Task<IActionResult> Edit(SaleDetailSearch search)
        {
            var result = await this.saleDetailApi.GetDetailBySale(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var sales = result.data;

            return View(sales);
        }

        public async Task<IActionResult> Details(SaleDetailSearch search)
        {
            var result = await this.saleDetailApi.GetDetailBySale(search);

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
        public async Task<IActionResult> Create(SaleDetailModel saleDetailModel)
        {
            saleDetailModel.ChangeDate = DateTime.Now;
            saleDetailModel.UserId = 1;
            var result = await this.saleDetailApi.SaveSaleDetail(saleDetailModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
