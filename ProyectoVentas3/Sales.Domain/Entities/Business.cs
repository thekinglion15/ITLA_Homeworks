using Sales.Domain.Core;

namespace Sales.Domain.Entities
{
    public class Business : BaseEntity
    {
        public string? DocNumber { get; set; }
        public string? Address { get; set; }
        public decimal? TaxPercent { get; set; }
        public string? CurrencySymbol { get; set; }
    }
}
