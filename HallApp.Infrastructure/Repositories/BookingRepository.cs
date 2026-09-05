using HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;
using HallApp.Entities.DatabaseEntities;
using HallApp.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HallApp.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly HallAppDbContext dbContext;

    public BookingRepository(HallAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateBookingAsync(BookingEntity bookingEntity)
    {
        await dbContext.BookingEntities.AddAsync(bookingEntity);
    }

    public async Task<bool> IsOverlapAsync(int hallId, DateTime startDate, DateTime endDate)
    {
        bool isOverlap = await dbContext.BookingEntities.AnyAsync(b =>
            b.HallId == hallId &&
            b.StartDate < endDate &&
            b.EndDate > startDate);

        return isOverlap;
    }
}
