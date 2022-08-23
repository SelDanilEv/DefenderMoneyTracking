using AutoMapper;
using Defender.MoneyTracking.Application.DTOs;
using Defender.MoneyTracking.Domain.Entities.User;

namespace Defender.MoneyTracking.Application.Common.Mappings;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(
            dest => dest.CreatedDate,
            opt => opt.MapFrom(
                src => src.CreatedDate.Value.ToShortDateString()));
    }
}
