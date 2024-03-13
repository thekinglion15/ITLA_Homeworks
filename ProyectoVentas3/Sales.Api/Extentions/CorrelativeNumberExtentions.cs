using Sales.Api.Models.CorrelativeNumber;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class CorrelativeNumberExtentions
    {
        public static CorrelativeNumber ConvertFromCorrelativeNumberCreateToCorrelativeNumber(this CorrelativeNumberCreateModel model)
        {
            return new CorrelativeNumber()
            {
                LastNumber = model.LastNumber,
                DigitsQuantity = model.DigitsQuantity,
                Management = model.Management,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
