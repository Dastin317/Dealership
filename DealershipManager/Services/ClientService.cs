using DealershipManager.Dtos;
using DealershipManager.Interfaces;
using SecondHandDealership.Models;

namespace DealershipManager.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientValidator _clientValidator;
        private readonly IClientRepository _clientRepository;

        public ClientService(
            IClientValidator clientValidator,
            IClientRepository clientRepository)
        {
            _clientValidator = clientValidator;
            _clientRepository = clientRepository;
        }

        public void Add(AddClientDto clientDto)
        {
            var isValid = _clientValidator.IsValidAddClientDto(clientDto); 

            if (!isValid) 
            {
                throw new ArgumentException("Invalid client information. Could not add the client.");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = clientDto.Name,
                IsCompany = clientDto.IsCompany,    
            };

            _clientRepository.Add(client);  
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}
