using Sales.Web.Models;
using Sales.Web.Models.Results;
using System.Text;
using System.Text.Json;

namespace Sales.Web.Services
{
    public class BusinessApiService : IBusinessApiService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<BusinessApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;

        public BusinessApiService(IConfiguration configuration, ILogger<BusinessApiService> logger, IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }

        public async Task<GetBusinessResult<List<BusinessResponseModel>>> GetBusinesses()
        {
            GetBusinessResult<List<BusinessResponseModel>> result = new GetBusinessResult<List<BusinessResponseModel>>();
            
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Business/GetBusinesses";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetBusinessResult<List<BusinessResponseModel>>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetBusinesses.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los departmanetos.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<GetBusinessResult<BusinessResponseModel>> GetBusinessByName(BusinessSearch businessSearch)
        {
            GetBusinessResult<BusinessResponseModel> result = new GetBusinessResult<BusinessResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Business/GetBusinessByName";

                    StringContent content = new StringContent(JsonSerializer.Serialize(businessSearch), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetBusinessResult<BusinessResponseModel>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetBusinessByName.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los negocios.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<ServiceResult> SaveBusiness(BusinessModel createModel)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Business/Save";

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
                                result.message = "Error conectandose al end point de Save Businesses.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = "Error guardando el negocio.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public Task<ServiceResult> UpdateBusiness(BusinessModel UpateModel)
        {
            throw new NotImplementedException();
        }
    }
}
