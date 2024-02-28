namespace Sales.Domain.Entities
{
    public class Menu : Core.BaseEntity
    {
        public int? IdMenuFather { get; set; }
        public string? Icon { get; set; }
        public string? Driver { get; set; }
        public string? ActionPage { get; set; }
    }
}
