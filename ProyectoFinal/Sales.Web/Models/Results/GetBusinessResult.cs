namespace Sales.Web.Models.Results
{
    public class GetBusinessResult<TModel> : ServiceResult
    {
        public TModel data { get; set; }
    }
}
