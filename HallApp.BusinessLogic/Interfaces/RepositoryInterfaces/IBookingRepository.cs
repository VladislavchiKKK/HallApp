using HallApp.Entities.DatabaseEntities;

namespace HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;

public interface IBookingRepository
{
    Task<bool> IsOverlapAsync(int hallId, DateTime startDate, DateTime endDate);

    Task CreateBookingAsync(BookingEntity bookingEntity);
}
