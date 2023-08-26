using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;

namespace SecondHandDealership.Repositories
{
    public class InMemoryCarRepository : ICarRepository
    {
        private static readonly List<Car> _cars = new List<Car>();

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Guid id)
        {
            var carToDelete = _cars.FirstOrDefault(c => c.Id == id);

            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public Car? Get(Guid id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Guid carId, Car car)
        {
            var carToUpdate = _cars.FirstOrDefault(c => c.Id == carId);

            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.ProductionYear = car.ProductionYear;
                carToUpdate.Description = car.Description;
                carToUpdate.Price = car.Price; 
                carToUpdate.Category = car.Category;
                carToUpdate.IsSold = car.IsSold;
            }
        }
    }
}
