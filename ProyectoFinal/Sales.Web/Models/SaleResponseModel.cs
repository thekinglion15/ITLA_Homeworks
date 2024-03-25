namespace Sales.Web.Models
{
    public class SaleResponseModel
    {
        public int Id { get; set; }
        public string? SaleNumber { get; set; }
        public int? IdTypeDocSale { get; set; }
        public int? IdUser { get; set; }
        public string? ClientDoc { get; set; }
        public string? NameClient { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public DateTime CreationDate { get; set; }
        public string StartDate { get; set; }
    }
}
