namespace Sales.AppServices.Models
{
    public class BusinessModel
    {
        public string? DocNumber { get; set; }
        public string? Address { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? CurrencySymbol { get; set; }
        public int IdCreationUser { get; set; }
    }
}
