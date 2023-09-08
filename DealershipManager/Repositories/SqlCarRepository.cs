using DealershipManager.Data;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;
using System.ComponentModel;

namespace DealershipManager.Repositories
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SqlCarRepository(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public void Add(Car car)
        {
            _applicationDbContext.Cars.Add(car);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carToDelete = _applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);

            if (carToDelete is not null)
            {
                _applicationDbContext.Cars.Remove(carToDelete);
                _applicationDbContext.SaveChanges();
            }
        }

        public List<Car> GetByFilter(List<string> models, List<string> brands, int startYear, int endYear)
        {
            var filter = _applicationDbContext.Cars.AsQueryable();

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

        public Car? Get(Guid id)
        {
            return _applicationDbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll(bool isSold)
        {
            return _applicationDbContext.Cars
                .Where(c => c.IsSold == isSold)
                .ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _applicationDbContext.Cars.FirstOrDefault(c => c.Id == car.Id);

            if (carToUpdate is not null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.ProductionYear = car.ProductionYear;
                carToUpdate.Description = car.Description;
                carToUpdate.Price = car.Price;
                carToUpdate.Category = car.Category;

                _applicationDbContext.SaveChanges();
            }
        }
    }
}
