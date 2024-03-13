namespace Sales.Infraestructure.Models
{
    public class ProductModel
    {
        public int IdProduct { get; set; }
        public string? BarCode { get; set; }
        public string? Brand { get; set; }
        public int? IdCategory { get; set; }
        public int? Stock { get; set; }
    }
}
