namespace Sales.Domain.Entities
{
    public class Configuration : Core.BaseEntity
    {
        public string? Resource { get; set; }
        public string? Property { get; set; }
        public string Value { get; set; }
    }
}
