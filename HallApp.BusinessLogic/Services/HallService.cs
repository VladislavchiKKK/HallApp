using AutoMapper;
using HallApp.BusinessLogic.DTOs;
using HallApp.BusinessLogic.Exceptions;
using HallApp.BusinessLogic.Interfaces;
using HallApp.BusinessLogic.Interfaces.ServiceInterfaces;
using HallApp.Entities.DatabaseEntities;

namespace HallApp.BusinessLogic.Services;

public class HallService : IHallService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public HallService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<int> CreateHallModelAsync(HallDto hallDto)
    {
        ValidateHallData(hallDto);

        var hallEntity = new HallEntity
        {
            Name = hallDto.Name,
            Capacity = hallDto.Capacity,
            PricePerHour = hallDto.PricePerHour,
        };

        if (hallDto.ServiceIds != null && hallDto.ServiceIds.Count > 0)
        {
            ICollection<int> uniqueIds = hallDto.ServiceIds
                .Distinct()
                .ToList();

            ICollection<ServiceEntity> existingServices = await unitOfWork.ServiceRepository.GetByIdsAsync(uniqueIds);

            if (existingServices.Count != uniqueIds.Count)
            {
                IEnumerable<int> foundIds = existingServices
                    .Select(s => s.Id)
                    .ToList();

                IEnumerable<int> missingIds = uniqueIds
                    .Where(id => !foundIds.Contains(id));

                throw new HallAppException($"Services with ids: {string.Join(", ", missingIds)} not found");
            }

            hallEntity.ServiceEntities = existingServices;
        }

        await unitOfWork.HallRepository.CreateHallAsync(hallEntity);
        await unitOfWork.SaveChangesAsync();

        return hallEntity.Id;
    }

    public async Task DeleteHallByIdAsync(int hallId)
    {
        HallEntity? hallEntity = await unitOfWork.HallRepository.GetHallByIdAsync(hallId);

        if (hallEntity == null) 
        {
            throw new HallAppException($"Hall with id: {hallId} not found");
        }

        unitOfWork.HallRepository.DeleteHall(hallEntity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateHallAsync(HallDto hallDto, int hallId)
    {
        HallEntity? hallEntity = await unitOfWork.HallRepository.GetHallByIdAsync(hallId);

        if (hallEntity == null)
        {
            throw new HallAppException($"Hall with id: {hallId} not found");
        }

        ValidateHallData(hallDto);

        hallEntity.Name = hallDto.Name;
        hallEntity.Capacity = hallDto.Capacity;
        hallEntity.PricePerHour = hallDto.PricePerHour;

        if (hallDto.ServiceIds != null && hallDto.ServiceIds.Count > 0)
        {
            ICollection<int> uniqueIds = hallDto.ServiceIds
                .Distinct()
                .ToList();

            ICollection<ServiceEntity> existingServices = await unitOfWork.ServiceRepository.GetByIdsAsync(uniqueIds);

            if (existingServices.Count != uniqueIds.Count)
            {
                IEnumerable<int> foundIds = existingServices
                    .Select(s => s.Id)
                    .ToList();

                IEnumerable<int> missingIds = uniqueIds
                    .Where(id => !foundIds.Contains(id));

                throw new HallAppException($"Services with ids: {string.Join(", ", missingIds)} not found");
            }

            hallEntity.ServiceEntities = existingServices;
        }
        else
        {
            hallEntity.ServiceEntities = [];
        }

        await unitOfWork.SaveChangesAsync();
    }

    public async Task<ICollection<HallDto>> SearchAvailableHallsAsync(FilterHallsDto dto)
    {
        if (dto.Capacity <= 0)
        {
            throw new HallAppException("Capacity must be greater than zero");
        }

        if (dto.EndDate <= dto.StartDate)
        {
            throw new HallAppException("End time must be after start time");
        }

        ICollection<HallEntity> availableHallEntities = await unitOfWork.HallRepository.SearchAvailableHallsAsync(dto.Capacity, dto.StartDate, dto.EndDate);

        ICollection<HallDto> hallDtos = mapper.Map<ICollection<HallDto>>(availableHallEntities);

        return hallDtos;

    }

    private static void ValidateHallData(HallDto hallDto)
    {
        if (string.IsNullOrWhiteSpace(hallDto.Name))
        {
            throw new HallAppException("Hall name can't be null or whitespace");
        }

        if (hallDto.Capacity <= 0)
        {
            throw new HallAppException("Hall capacity must be greater than zero");
        }

        if (hallDto.PricePerHour <= 0)
        {
            throw new HallAppException("Hall price per hour must be greater than zero");
        }
    }

}
