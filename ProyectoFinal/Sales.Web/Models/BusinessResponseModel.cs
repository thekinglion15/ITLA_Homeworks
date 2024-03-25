namespace Sales.Web.Models
{
    public class BusinessResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? DocNumber { get; set; }
        public string? Address { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? CurrencySymbol { get; set; }
        public DateTime CreationDate { get; set; }
        public string StartDate { get; set; }
    }
}
