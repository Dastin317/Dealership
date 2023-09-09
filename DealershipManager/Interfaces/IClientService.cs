using DealershipManager.Dtos;
using DealershipManager.Models;
using SecondHandDealership.Models;

namespace DealershipManager.Interfaces
{
    public interface IClientService
    {
        Result Add(AddClientDto clientDto);

        GenericResult<List<Client>> GetAll();
    }
}
