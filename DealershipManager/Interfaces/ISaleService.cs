using DealershipManager.Dtos;
using DealershipManager.Models;
using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ISaleService
    {
        Result Add(AddSaleDto saleDto);

        GenericResult<List<Sale>> GetAll(DateTime startDate, DateTime endDate);
    }
}
