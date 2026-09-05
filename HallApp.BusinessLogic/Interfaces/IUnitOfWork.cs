using HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;

namespace HallApp.BusinessLogic.Interfaces;

public interface IUnitOfWork
{
    IHallRepository HallRepository { get; }

    IServiceRepository ServiceRepository { get; }

    IBookingRepository BookingRepository { get; }

    Task SaveChangesAsync();
}
