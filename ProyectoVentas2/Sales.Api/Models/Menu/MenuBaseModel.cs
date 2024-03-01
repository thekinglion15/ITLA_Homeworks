namespace Sales.Api.Models.Menu
{
    public class MenuBaseModel : BaseModel
    {
        public int? IdMenuFather { get; set; }
        public string? Icon { get; set; }
        public string? Driver { get; set; }
        public string? ActionPage { get; set; }
    }
}
