﻿using Sales.Api.Models.Sale;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class SaleExtentions
    {
        public static Sale ConvertFromSaleCreateToSale(this SaleCreateModel model)
        {
            return new Sale()
            {
                SaleNumber = model.SaleNumber,
                IdTypeDocSale = model.IdTypeDocSale,
                IdUser = model.IdUser,
                ClientDoc = model.ClientDoc,
                NameClient = model.NameClient,
                Subtotal = model.Subtotal,
                TaxTotal = model.TaxTotal,
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
