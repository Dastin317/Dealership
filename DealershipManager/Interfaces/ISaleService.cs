using DealershipManager.Dtos;
using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ISaleService
    {
        void Add(AddSaleDto saleDto);

        List<Sale> GetAll(DateTime startDate, DateTime endDate);
    }
}
