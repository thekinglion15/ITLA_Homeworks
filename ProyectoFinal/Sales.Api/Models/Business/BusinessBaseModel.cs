namespace Sales.Api.Models.Business
{
    public class BusinessBaseModel : BaseModel
    {
        public string? DocNumber { get; set; }
        public string? Address { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? CurrencySymbol { get; set; }
    }
}
