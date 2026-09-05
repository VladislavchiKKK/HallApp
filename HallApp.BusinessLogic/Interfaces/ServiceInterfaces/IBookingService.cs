using HallApp.BusinessLogic.DTOs;

namespace HallApp.BusinessLogic.Interfaces.ServiceInterfaces;

public interface IBookingService
{
    Task<decimal> CreateBookingAsync(CreateBookingDto dto);
}
