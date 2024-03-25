namespace Sales.Web.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public string? SaleNumber { get; set; }
        public int? IdTypeDocSale { get; set; }
        public int? IdUser { get; set; }
        public string? ClientDoc { get; set; }
        public string? NameClient { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public int UserId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
