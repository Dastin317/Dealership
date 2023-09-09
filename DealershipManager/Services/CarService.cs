using DealershipManager.Dtos;
using DealershipManager.Exceptions;
using DealershipManager.Interfaces;
using DealershipManager.Models;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;
using System.Collections.Generic;

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
        public Result Add(AddCarDto carDto)
        {
            var isValid = _carValidator.IsValidAddCarDto(carDto);

            if (!isValid)
            {
                return Result.Fail("Invalid car information. Could not add the car.");
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
            return Result.Success();
        }

        public Result Delete(Guid id)
        {
            _carRepository.Delete(id);

            return Result.Success();
        }

        public GenericResult<Car> Get(Guid id)
        {
            var car = _carRepository.Get(id);

            if (car is null) 
            {
                return GenericResult<Car>.Fail($"Could not find the car with the following id: {id}");
            }

            return GenericResult<Car>.Success(car);
        }

        public GenericResult<List<Car>> GetAll(bool isSold)
        {
            return GenericResult<List<Car>>.Success(_carRepository.GetAll(isSold));
        }

        public Result Update(Guid carId, UpdateCarDto carDto)
        {
            var isValid = _carValidator.IsValidUpdateCarDto(carDto);

            if (!isValid)
            {
                return Result.Fail("Invalid car information. Could not update the car.");
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

            return Result.Success();
        }
    }
}
