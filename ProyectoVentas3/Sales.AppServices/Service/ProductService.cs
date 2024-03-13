using Microsoft.Extensions.Logging;
using Sales.AppServices.Contracts;
using Sales.AppServices.Core;
using Sales.Infraestructure.Interfaces;

namespace Sales.AppServices.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductDb productDb;
        private readonly ILogger<ProductService> logger;

        public ProductService(IProductDb productDb, ILogger<ProductService> logger)
        {
            this.productDb = productDb;
            this.logger = logger;
        }

        public ServiceResult GetProducts()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetProductsByDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetProductsCount()
        {
            throw new NotImplementedException();
        }
    }
}
