namespace Sales.AppServices.Models
{
    public class SaleModel
    {
        public string? SaleNumber { get; set; }
        public int? IdTypeDocSale { get; set; }
        public int? IdUser { get; set; }
        public string? ClientDoc { get; set; }
        public string? NameClient { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public int IdCreationUser { get; set; }
    }
}
