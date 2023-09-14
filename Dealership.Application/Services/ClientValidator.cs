using DealershipManager.Dtos;
using DealershipManager.Interfaces;

namespace DealershipManager.Services
{
    public class ClientValidator : IClientValidator
    {
        public bool IsValidAddClientDto(AddClientDto clientDto)
        {
            if (string.IsNullOrEmpty(clientDto.Name)) return false;

            return true;
        }
    }
}
