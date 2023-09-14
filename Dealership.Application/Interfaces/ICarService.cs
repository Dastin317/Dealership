using DealershipManager.Dtos;
using DealershipManager.Models;
using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ICarService
    {
        Result Add(AddCarDto carDto);

        GenericResult<Car> Get(Guid id);

        GenericResult<List<Car>> GetAll(bool isSold); 

        Result Update(Guid carId, UpdateCarDto carDto);

        Result Delete(Guid id);
    }
}
