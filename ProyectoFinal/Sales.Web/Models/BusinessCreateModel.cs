namespace Sales.Web.Models
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public string? DocNumber { get; set; }
        public string? Address { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? CurrencySymbol { get; set; }
        public int UserId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
