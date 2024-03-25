namespace Sales.Web.Models
{
    public class SaleDetailResponseModel
    {
        public int Id { get; set; }
        public int? IdSale { get; set; }
        public int? IdProduct { get; set; }
        public string? BrandProduct { get; set; }
        public string? ProductCategory { get; set; }
        public int? Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        public string StartDate { get; set; }
    }
}
