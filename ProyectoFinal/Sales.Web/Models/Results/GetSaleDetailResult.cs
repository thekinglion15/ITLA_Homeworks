namespace Sales.Web.Models.Results
{
    public class GetSaleDetailResult<TModel> : ServiceResult
    {
        public TModel data { get; set; }
    }
}
