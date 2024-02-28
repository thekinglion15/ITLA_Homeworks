namespace Sales.Domain.Entities
{
    public class CorrelativeNumber : Core.BaseEntity
    {
        public int? LastNumber { get; set; }
        public int? DigitsQuantity { get; set; }
        public string? Management { get; set; }
    }
}
