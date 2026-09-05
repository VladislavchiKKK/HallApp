using HallApp.BusinessLogic.Interfaces;
using HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;
using HallApp.Infrastructure.DatabaseContext;

namespace HallApp.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly HallAppDbContext dbContext;

    public UnitOfWork(HallAppDbContext dbContext)
    {
        this.dbContext = dbContext;
        HallRepository = new HallRepository(dbContext);
        ServiceRepository = new ServiceRepository(dbContext);
        BookingRepository = new BookingRepository(dbContext);
    }

    public IHallRepository HallRepository { get; }

    public IServiceRepository ServiceRepository { get; }

    public IBookingRepository BookingRepository { get; }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
