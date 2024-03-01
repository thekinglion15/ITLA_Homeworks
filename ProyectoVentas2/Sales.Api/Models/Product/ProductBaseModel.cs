namespace Sales.Api.Models.Product
{
    public class ProductBaseModel : BaseModel
    {
        public string? BarCode { get; set; }
        public string? Brand { get; set; }
        public int? IdCategory { get; set; }
        public int? Stock { get; set; }
    }
}
