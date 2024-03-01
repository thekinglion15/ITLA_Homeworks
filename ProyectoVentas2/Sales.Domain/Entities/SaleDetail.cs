using Sales.Domain.Core;

namespace Sales.Domain.Entities
{
    public class SaleDetail : BaseEntity
    {
        public int? IdSale { get; set; }
        public int? IdProduct { get; set; }
        public string? BrandProduct { get; set; }
        public string? ProductCategory { get; set; }
        public int? Quantity { get; set; }
    }
}
