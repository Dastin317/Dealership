using SecondHandDealership.Models;

namespace DealershipManager.Interfaces
{
    public interface ISaleRepository
    {
        void Add(Sale sale);

        List<Sale> GetAll(DateTime startDate, DateTime endDate);
    }
}
