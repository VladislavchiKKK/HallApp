using HallApp.Entities.DatabaseEntities;

namespace HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;

public interface IHallRepository
{
    Task CreateHallAsync(HallEntity hallEntity);

    void DeleteHall(HallEntity hallEntity);

    Task<HallEntity?> GetHallByIdAsync(int id);

    void UpdateHall(HallEntity hallEntity);

    Task<ICollection<HallEntity>> SearchAvailableHallsAsync(int capacity, DateTime startDate, DateTime endDate);
}
