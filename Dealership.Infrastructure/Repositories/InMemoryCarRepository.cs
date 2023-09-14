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

        public List<Car> GetAll(bool isSold)
        {
            return _cars.Where(c => c.IsSold == isSold).ToList();
        }

        public List<Car> GetByFilter(List<string> models, List<string> brands, int startYear, int endYear)
        {
            var filter = _cars.AsQueryable();

            if (models.Any())
            {
                filter = filter.Where(c => models.Contains(c.Model));
            }

            if (brands.Any())
            {
                filter = filter.Where(c => brands.Contains(c.Brand));
            }

            if (startYear != 0 && endYear != 0)
            {
                filter = filter.Where(c => c.ProductionYear >= startYear && c.ProductionYear <= endYear);
            }

            var cars = filter.ToList();

            return cars;
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);

            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.ProductionYear = car.ProductionYear;
                carToUpdate.Description = car.Description;
                carToUpdate.Price = car.Price; 
                carToUpdate.Category = car.Category;
            }
        }
    }
}
