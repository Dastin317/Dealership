using DealershipManager.Dtos;
using DealershipManager.Interfaces;
using DealershipManager.Models;
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

        public Result Add(AddClientDto clientDto)
        {
            var isValid = _clientValidator.IsValidAddClientDto(clientDto); 

            if (!isValid) 
            {
                return Result.Fail("Invalid client information. Could not add the client.");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = clientDto.Name,
                IsCompany = clientDto.IsCompany,    
            };

            _clientRepository.Add(client);

            return Result.Success();
        }

        public GenericResult<List<Client>> GetAll()
        {
            return GenericResult<List<Client>>.Success(_clientRepository.GetAll());
        }
    }
}
