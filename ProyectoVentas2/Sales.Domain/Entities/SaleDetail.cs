namespace Sales.Domain.Entities
{
    public class SaleDetail : Core.BaseEntity
    {
        public int? IdSale { get; set; }
        public int? IdProduct { get; set; }
        public string? BrandProduct { get; set; }
        public string? ProductCategory { get; set; }
        public int? Quantity { get; set; }
    }
}
