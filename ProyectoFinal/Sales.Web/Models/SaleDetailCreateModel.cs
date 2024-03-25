namespace Sales.Web.Models
{
    public class SaleDetailModel
    {
        public int Id { get; set; }
        public int? IdSale { get; set; }
        public int? IdProduct { get; set; }
        public string? BrandProduct { get; set; }
        public string? ProductCategory { get; set; }
        public int? Quantity { get; set; }
        public int UserId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
