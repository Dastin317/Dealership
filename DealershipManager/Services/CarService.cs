using DealershipManager.Dtos;
using DealershipManager.Exceptions;
using DealershipManager.Interfaces;
using DealershipManager.Models;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;

namespace SecondHandDealership.Services
{
    public class CarService : ICarService
    {
        private readonly ICarValidator _carValidator;
        private readonly ICarRepository _carRepository;

        public CarService(
            ICarValidator carValidator,
            ICarRepository carRepository)
        {
            _carValidator = carValidator;
             _carRepository = carRepository;
        }
        public void Add(AddCarDto carDto)
        {
            var isValid = _carValidator.IsValidAddCarDto(carDto);

            if (!isValid)
            {
                throw new ValidationException("Invalid car information. Could not add the car.");
            }

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = carDto.Brand,
                Model = carDto.Model,
                Category = carDto.Category,
                Description = carDto.Description,
                ProductionYear = carDto.ProductionYear,
                Price = carDto.Price,
                IsSold = false
            }; 

            _carRepository.Add(car);
        }

        public void Delete(Guid id)
        {
            _carRepository.Delete(id);
        }

        public Car? Get(Guid id)
        {
            var car = _carRepository.Get(id);

            if (car is null) 
            {
                throw new NotFoundException(id);
            }

            return car;
        }

        public List<Car> GetAll(bool isSold)
        {
            return _carRepository.GetAll(isSold);
        }

        public void Update(Guid carId, UpdateCarDto carDto)
        {
            var isValid = _carValidator.IsValidUpdateCarDto(carDto);

            if (!isValid)
            {
                throw new ValidationException("Invalid car information. Could not update the car.");
            }

            var car = new Car
            {
                Id = carId,
                Brand = carDto.Brand,
                Model = carDto.Model,
                Category = carDto.Category,
                ProductionYear = carDto.ProductionYear,
                Price = carDto.Price
            };

            _carRepository.Update(car);
        }
    }
}
