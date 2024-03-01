using Sales.Domain.Core;

namespace Sales.Domain.Entities
{
    public class Configuration : BaseEntity
    {
        public string? Resource { get; set; }
        public string? Property { get; set; }
        public string Value { get; set; }
    }
}
