using Sales.Web.Models;
using Sales.Web.Models.Results;
using System.Text;
using System.Text.Json;

namespace Sales.Web.Services
{
    public class SaleDetailApiService : ISaleDetailApiService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<SaleDetailApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;

        public SaleDetailApiService(IConfiguration configuration, ILogger<SaleDetailApiService> logger, IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<GetSaleDetailResult<List<SaleDetailResponseModel>>> GetSaleDetails()
        {
            GetSaleDetailResult<List<SaleDetailResponseModel>> result = new GetSaleDetailResult<List<SaleDetailResponseModel>>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/SaleDetail/GetSaleDetails";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetSaleDetailResult<List<SaleDetailResponseModel>>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetSaleDetails.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los detalles de ventas.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetSaleDetailResult<SaleDetailResponseModel>> GetDetailBySale(SaleDetailSearch saleDetailSearch)
        {
            GetSaleDetailResult<SaleDetailResponseModel> result = new GetSaleDetailResult<SaleDetailResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Sale/GetSaleDetailBySale";

                    StringContent content = new StringContent(JsonSerializer.Serialize(saleDetailSearch), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetSaleDetailResult<SaleDetailResponseModel>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetSaleDetailBySale.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los detalles de ventas.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<ServiceResult> SaveSaleDetail(SaleDetailModel createModel)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/SaleDetail/Save";

                    StringContent content = new StringContent(JsonSerializer.Serialize(createModel), Encoding.UTF8, "application/json");
                    string resp = string.Empty;
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<ServiceResult>(resp);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result = JsonSerializer.Deserialize<ServiceResult>(resp);
                                return result;
                            }
                            else
                            {
                                result.success = false;
                                result.message = "Error conectandose al end point de Save SaleDetails.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = "Error guardando el detalle de venta.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public Task<ServiceResult> UpdateSaleDetail(SaleDetailModel UpateModel)
        {
            throw new NotImplementedException();
        }
    }
}
