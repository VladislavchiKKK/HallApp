using HallApp.BusinessLogic.DTOs;

namespace HallApp.BusinessLogic.Interfaces.ServiceInterfaces;

public interface IHallService
{
    Task<int> CreateHallModelAsync(HallDto hallDto);

    Task DeleteHallByIdAsync(int hallId);

    Task UpdateHallAsync(HallDto hallDto, int hallId);

    Task<ICollection<HallDto>> SearchAvailableHallsAsync(FilterHallsDto dto);
}
