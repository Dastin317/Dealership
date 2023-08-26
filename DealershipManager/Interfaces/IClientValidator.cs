using DealershipManager.Dtos;

namespace DealershipManager.Interfaces
{
    public interface IClientValidator
    {
        bool IsValidAddClientDto(AddClientDto clientDto);
    }
}
