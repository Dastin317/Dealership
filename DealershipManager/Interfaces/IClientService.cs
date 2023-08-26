using DealershipManager.Dtos;
using SecondHandDealership.Models;

namespace DealershipManager.Interfaces
{
    public interface IClientService
    {
        void Add(AddClientDto clientDto);

        List<Client> GetAll();
    }
}
