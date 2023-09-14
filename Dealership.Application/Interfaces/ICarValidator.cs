using DealershipManager.Dtos;

namespace DealershipManager.Interfaces
{
    public interface ICarValidator
    {
        bool IsValidAddCarDto(AddCarDto carDto);

        bool IsValidUpdateCarDto(UpdateCarDto carDto);
    }
}
