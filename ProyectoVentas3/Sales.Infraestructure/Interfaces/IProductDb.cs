using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IProductDb : IDaoBase<Product>
    {
        List<ProductModel> GetProductsByDates(DateTime startDate, DateTime endDate);
        List<ProductModel> GetProductsCount();
        List<ProductModel> GetProducts();
    }
}
