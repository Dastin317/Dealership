using DealershipManager.Dtos;
using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ICarService
    {
        void Add(AddCarDto carDto);

        Car? Get(Guid id);

        List<Car> GetAll();

        void Update(Guid carId, UpdateCarDto carDto);

        void Delete(Guid id);
    }
}
