using Microsoft.AspNetCore.Mvc;
using Sales.Web.Models;
using Sales.Web.Services;

namespace Sales.Web.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessApiService businessApi;

        public BusinessController(IBusinessApiService businessApi)
        {
            this.businessApi = businessApi;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this.businessApi.GetBusinesses();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var businesses = result.data;

            return View(businesses);
        }

        public async Task<IActionResult> Edit(BusinessSearch search)
        {
            var result = await this.businessApi.GetBusinessByName(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var businesses = result.data;

            return View(businesses);
        }

        public async Task<IActionResult> Details(BusinessSearch search)
        {
            var result = await this.businessApi.GetBusinessByName(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var businesses = result.data;

            return View(businesses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusinessModel businessModel)
        {
            businessModel.ChangeDate = DateTime.Now;
            businessModel.UserId = 1;
            var result = await this.businessApi.SaveBusiness(businessModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
