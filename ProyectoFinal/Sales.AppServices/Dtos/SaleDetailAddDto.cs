﻿namespace Sales.AppServices.Dtos
{
    public record SaleDetailAddDto
    {
        public int? IdSale { get; set; }
        public int? IdProduct { get; set; }
        public string? BrandProduct { get; set; }
        public string? ProductCategory { get; set; }
        public int? Quantity { get; set; }
        public int IdCreationUser { get; set; }
    }
}
