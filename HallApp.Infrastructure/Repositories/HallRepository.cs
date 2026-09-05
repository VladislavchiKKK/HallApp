using HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;
using HallApp.Entities.DatabaseEntities;
using HallApp.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HallApp.Infrastructure.Repositories;

public class HallRepository : IHallRepository
{
    private readonly HallAppDbContext dbContext;

    public HallRepository(HallAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateHallAsync(HallEntity hallEntity)
    {
        await dbContext.HallEntities.AddAsync(hallEntity);
    }

    public void DeleteHall(HallEntity hallEntity)
    {
        dbContext.HallEntities.Remove(hallEntity);
    }

    public async Task<HallEntity?> GetHallByIdAsync(int id)
    {
        return await dbContext.HallEntities
            .Include(h => h.ServiceEntities)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<ICollection<HallEntity>> SearchAvailableHallsAsync(int capacity, DateTime startDate, DateTime endDate)
    {
        ICollection<HallEntity> hallEntities = await dbContext.HallEntities
            .Include(h => h.ServiceEntities)
            .Where(h => h.Capacity >= capacity)
            .Where(h => !dbContext.BookingEntities.Any(b =>
                b.HallId == h.Id &&
                b.StartDate < endDate &&
                b.EndDate > startDate))
            .ToListAsync();

        return hallEntities;
    }

    public void UpdateHall(HallEntity hallEntity)
    {
        dbContext.HallEntities.Update(hallEntity);
    }
}
