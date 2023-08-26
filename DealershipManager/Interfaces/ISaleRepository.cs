using SecondHandDealership.Models;

namespace DealershipManager.Interfaces
{
    public interface ISaleRepository
    {
        void Add(Sale sale);

        List<Sale> GetAll();
    }
}
