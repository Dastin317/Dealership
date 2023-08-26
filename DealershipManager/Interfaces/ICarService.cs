using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ICarService
    {
        void Add(Car car);

        Car? Get(Guid id);

        List<Car> GetAll();

        void Update(Guid carId, Car car);

        void Delete(Guid id);
    }
}
