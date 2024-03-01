using Sales.Domain.Core;

namespace Sales.Domain.Entities
{
    public class CorrelativeNumber : BaseEntity
    {
        public int? LastNumber { get; set; }
        public int? DigitsQuantity { get; set; }
        public string? Management { get; set; }
    }
}
