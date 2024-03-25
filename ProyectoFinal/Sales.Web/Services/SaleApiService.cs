using Sales.Web.Models;
using Sales.Web.Models.Results;
using System.Text;
using System.Text.Json;

namespace Sales.Web.Services
{
    public class SaleApiService : ISaleApiService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<SaleApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;

        public SaleApiService(IConfiguration configuration, ILogger<SaleApiService> logger, IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<GetSaleResult<List<SaleResponseModel>>> GetSales()
        {
            GetSaleResult<List<SaleResponseModel>> result = new GetSaleResult<List<SaleResponseModel>>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Sale/GetSales";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetSaleResult<List<SaleResponseModel>>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetSales.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo las ventas.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetSaleResult<SaleResponseModel>> GetSaleBySaleNumber(SaleSearch saleSearch)
        {
            GetSaleResult<SaleResponseModel> result = new GetSaleResult<SaleResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Sale/GetSaleBySaleNumber";

                    StringContent content = new StringContent(JsonSerializer.Serialize(saleSearch), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetSaleResult<SaleResponseModel>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetSaleBySaleNumber.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo las ventas.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<ServiceResult> SaveSale(SaleModel createModel)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Sale/Save";

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
                                result.message = "Error conectandose al end point de Save Sales.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = "Error guardando la venta.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public Task<ServiceResult> UpdateSale(SaleModel UpateModel)
        {
            throw new NotImplementedException();
        }
    }
}
