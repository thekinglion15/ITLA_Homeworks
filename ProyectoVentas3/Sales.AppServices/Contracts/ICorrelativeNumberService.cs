using Sales.AppServices.Core;

namespace Sales.AppServices.Contracts
{
    public interface ICorrelativeNumberService
    {
        ServiceResult GetCorrelativeNumbersByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetCorrelativeNumbersCount();
        ServiceResult GetCorrelativeNumbers();
    }
}
