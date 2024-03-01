using Microsoft.AspNetCore.Mvc;
using Sales.Infraestructure.Interfaces;
using Sales.Domain.Entities;
using Sales.Api.Models.Product;
using Sales.Infraestructure.DAO;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDb productDb;

        public ProductController(IProductDb productDb)
        {
            this.productDb = productDb;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = this.productDb.GetAll();

            return Ok(products);
        }

        [HttpPost("Save")]
        public IActionResult Save(ProductCreateModel createModel)
        {
            var result = this.productDb.Save(new Product()
            {
                ModifyDate = createModel.ModifyDate,
                IdCreationUser = createModel.IdCreationUser,
                BarCode = createModel.BarCode,
                Brand = createModel.Brand,
                IdCategory = createModel.IdCategory,
                Stock = createModel.Stock
            });

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(ProductCreateModel updateProduct)
        {
            var result = this.productDb.Save(new Product()
            {
                ModifyDate = updateProduct.ModifyDate,
                IdCreationUser = updateProduct.IdCreationUser,
                BarCode = updateProduct.BarCode,
                Brand = updateProduct.Brand,
                IdCategory = updateProduct.IdCategory,
                Stock = updateProduct.Stock
            });

            return Ok(result);
        }
    }
}
