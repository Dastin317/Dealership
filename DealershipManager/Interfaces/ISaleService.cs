using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ISaleService
    {
        void Add(Sale sale);

        Sale Get(Guid id);

        List<Sale> GetAll();

        void Delete(Guid id);

        void Update(Sale sale); 
    }
}
