using Sales.Domain.Core;

namespace Sales.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? BarCode { get; set; }
        public string? Brand { get; set; }
        public int? IdCategory { get; set; }
        public int? Stock { get; set; }
    }
}
