namespace Sales.Web.Models.Results
{
    public class GetSaleResult<TModel> : ServiceResult
    {
        public TModel data { get; set; }
    }
}
