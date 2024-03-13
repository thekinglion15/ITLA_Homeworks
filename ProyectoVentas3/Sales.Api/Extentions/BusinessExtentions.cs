using Sales.Api.Models.Business;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class BusinessExtentions
    {
        public static Business ConvertFromBusinessCreateToBusiness(this BusinessCreateModel model)
        {
            return new Business()
            {
                DocNumber = model.DocNumber,
                Address = model.Address,
                TaxPercent = model.TaxPercent,
                CurrencySymbol = model.CurrencySymbol,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
