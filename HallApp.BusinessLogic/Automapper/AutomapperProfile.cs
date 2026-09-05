using AutoMapper;
using HallApp.BusinessLogic.DTOs;
using HallApp.Entities.DatabaseEntities;

namespace HallApp.BusinessLogic.Automapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<HallEntity, HallDto>()
            .ForMember(h => h.ServiceIds, opt => opt.MapFrom(he => he.ServiceEntities.Select(s => s.Id)));
    }
}
