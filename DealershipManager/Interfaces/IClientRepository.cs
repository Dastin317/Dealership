using SecondHandDealership.Models;

namespace DealershipManager.Interfaces
{
    public interface IClientRepository
    {
        void Add(Client client);

        Client? Get(Guid id);

        List<Client> GetAll(); 

        void Update(Client client);

        void Delete(Guid id);
    }
}
