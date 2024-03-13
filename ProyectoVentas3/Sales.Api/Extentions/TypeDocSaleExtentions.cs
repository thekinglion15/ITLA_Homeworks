using Sales.Api.Models.TypeDocSale;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class TypeDocSaleExtentions
    {
        public static TypeDocSale ConvertFromTypeDocSaleCreateToTypeDocSale(this TypeDocSaleCreateModel model)
        {
            return new TypeDocSale()
            {
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
