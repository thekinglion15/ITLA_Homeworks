namespace Sales.Api.Models.CorrelativeNumber
{
    public class CorrelativeNumberBaseModel : BaseModel
    {
        public int? LastNumber { get; set; }
        public int? DigitsQuantity { get; set; }
        public string? Management { get; set; }
    }
}
