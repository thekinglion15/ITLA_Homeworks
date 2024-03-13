using Sales.Domain.Entities;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Interfaces
{
    public interface IBusinessDb : IDaoBase<Business>
    {
        List<BusinessModel> GetBusinessesByDates(DateTime startDate, DateTime endDate);
        List<BusinessModel> GetBusinessesCount();
        List<BusinessModel> GetBusinesses();
    }
}