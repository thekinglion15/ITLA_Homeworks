using Sales.Api.Models.Product;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class ProductExtentions
    {
        public static Product ConvertFromProductCreateToProduct(this ProductCreateModel model)
        {
            return new Product()
            {
                BarCode = model.BarCode,
                Brand = model.Brand,
                IdCategory = model.IdCategory,
                Stock = model.Stock,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
