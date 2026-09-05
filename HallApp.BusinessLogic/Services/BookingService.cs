using HallApp.BusinessLogic.DTOs;
using HallApp.BusinessLogic.Exceptions;
using HallApp.BusinessLogic.Interfaces;
using HallApp.BusinessLogic.Interfaces.ServiceInterfaces;
using HallApp.Entities.DatabaseEntities;

namespace HallApp.BusinessLogic.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IPricingService pricingService;

    public BookingService(IUnitOfWork unitOfWork, IPricingService pricingService)
    {
        this.unitOfWork = unitOfWork;
        this.pricingService = pricingService;
    }

    public async Task<decimal> CreateBookingAsync(CreateBookingDto dto)
    {
        if (dto.DurationHours <= 0) 
        {
            throw new HallAppException("Duration must be greater than zero");
        }

        DateTime endTime = dto.StartDateTime.AddHours(dto.DurationHours);

        HallEntity? hall = await unitOfWork.HallRepository.GetHallByIdAsync(dto.HallId);

        if (hall == null)
        {
            throw new HallAppException($"Hall with id {dto.HallId} not found");
        }

        ICollection<ServiceEntity> selectedServices = [];

        if (dto.ServiceIds != null && dto.ServiceIds.Count > 0)
        {
            ICollection<int> hallServiceIds = hall.ServiceEntities
                .Select(s => s.Id)
                .ToList();

            ICollection<int> invalidIds = dto.ServiceIds
                .Where(id => !hallServiceIds.Contains(id))
                .ToList();

            if (invalidIds.Count > 0)
            {
                throw new HallAppException($"Services with ids: {string.Join(", ", invalidIds)} not available");
            }

            selectedServices = hall.ServiceEntities
                .Where(s => dto.ServiceIds.Contains(s.Id))
                .ToList();
        }

        bool isOverlap = await unitOfWork.BookingRepository.IsOverlapAsync(dto.HallId, dto.StartDateTime, endTime);

        if (isOverlap)
        {
            throw new HallAppException($"Hall {dto.HallId} already booked");
        }

        decimal roomTotalPrice = pricingService.CalculateTotalPrice(dto.StartDateTime, endTime, hall.PricePerHour);
        decimal servicesTotalPrice = selectedServices.Sum(s => s.Price);
        decimal totalPrice = servicesTotalPrice + roomTotalPrice;

        BookingEntity bookingEntity = new BookingEntity
        {
            HallId = dto.HallId,
            StartDate = dto.StartDateTime,
            EndDate = endTime,
            TotalPrice = totalPrice,
            ServiceEntities = selectedServices
        };

        await unitOfWork.BookingRepository.CreateBookingAsync(bookingEntity);
        await unitOfWork.SaveChangesAsync();

        return totalPrice;
    }
}
