using Sales.Api.Models.Business;
using Sales.Api.Models.SaleDetail;
using Sales.AppServices.Dtos;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class SaleDetailExtentions
    {
        public static SaleDetail ConvertFromSaleDetailCreateToSaleDetail(this SaleDetailCreateModel model)
        {
            return new SaleDetail()
            {
                IdSale = model.IdSale,
                IdProduct = model.IdProduct,
                BrandProduct = model.BrandProduct,
                ProductCategory = model.ProductCategory,
                Quantity = model.Quantity,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }

        public static SaleDetailAddDto ConvertFromSaleDetailCreateToSaleDetailDto(this SaleDetailCreateModel model)
        {
            return new SaleDetailAddDto()
            {
                IdSale = model.IdSale,
                IdProduct = model.IdProduct,
                BrandProduct = model.BrandProduct,
                ProductCategory = model.ProductCategory,
                Quantity = model.Quantity,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
