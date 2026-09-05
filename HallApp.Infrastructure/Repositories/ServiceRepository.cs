using HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;
using HallApp.Entities.DatabaseEntities;
using HallApp.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HallApp.Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly HallAppDbContext dbContext;

    public ServiceRepository(HallAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ICollection<ServiceEntity>> GetByIdsAsync(IEnumerable<int> ids)
    {
        ICollection<ServiceEntity> serviceEntities = await dbContext.ServiceEntities
            .Where(s => ids.Contains(s.Id))
            .ToListAsync();

        return serviceEntities;
    }
}
