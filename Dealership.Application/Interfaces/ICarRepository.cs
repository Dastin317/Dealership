using SecondHandDealership.Models;

namespace SecondHandDealership.Interfaces
{
    public interface ICarRepository
    {
        void Add(Car car);

        Car? Get(Guid id);

        List<Car> GetAll(bool isSold);

        List<Car> GetByFilter(List<string> models, List<string> brands, int startYear, int endYear);

        void Update(Car car);

        void Delete(Guid id);
    }
}