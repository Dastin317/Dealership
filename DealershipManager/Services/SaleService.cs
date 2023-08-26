using DealershipManager.Dtos;
using DealershipManager.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using SecondHandDealership.Interfaces;
using SecondHandDealership.Models;

namespace SecondHandDealership.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICarRepository _carRepository;

        public SaleService(
            ICarRepository carRepository, 
            IClientRepository clientRepository,
            ISaleRepository saleRepository)
        {
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            _saleRepository = saleRepository;
        }

        public void Add(AddSaleDto saleDto)
        {
            var car = _carRepository.Get(saleDto.CarId);
            var isValidCar = IsValidCar(car);

            var client = _clientRepository.Get(saleDto.ClientId);   
            var isValidClient = IsValidClient(client);

            if (!isValidClient || !isValidCar || saleDto.FinalPrice < 0)
            {
                throw new ArgumentException("Invalid sale data. Could not register sale.");
            }
            else
            {
                var sale = new Sale
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.UtcNow,
                    Car = car,
                    Client = client,
                    FinalPrice = saleDto.FinalPrice,
                };

                _saleRepository.Add(sale);

                car.IsSold = true;
                _carRepository.Update(car);
            }
        }

        public List<Sale> GetAll()
        {
            return _saleRepository.GetAll();
        }

        private bool IsValidCar(Car? car)
        {
            if (car is null)
            {
                return false;
            }
            if (car.IsSold)
            {
                return false;
            }

            return true;
        }
        private bool IsValidClient(Client? client)
        {
            if (client is null)
            {
                return false;
            }

            return true;
        }
    }
}
