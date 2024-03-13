namespace Sales.Infraestructure.Models
{
    public class SaleModel
    {
        public string? DocNumber { get; set; }
        public string? Address { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? CurrencySymbol { get; set; }
        public int IdUser { get; set; }
        public int Quantity { get; set; }
    }
}
