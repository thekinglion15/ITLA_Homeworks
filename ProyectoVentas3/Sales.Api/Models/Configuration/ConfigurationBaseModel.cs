namespace Sales.Api.Models.Configuration
{
    public class ConfigurationBaseModel : BaseModel
    {
        public string? Resource { get; set; }
        public string? Property { get; set; }
        public string Value { get; set; }
    }
}
