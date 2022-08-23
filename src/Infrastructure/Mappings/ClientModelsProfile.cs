using AutoMapper;

namespace Defender.MoneyTracking.Infrastructure.Mappings;

public class ClientModelsProfile : Profile
{
    public ClientModelsProfile()
    {
        CreateMap<
            Clients.UserManagement.LoginResponse,
            Application.Models.LoginResponse.LoginResponse>();

        CreateMap<
            Clients.UserManagement.UserDto,
            Application.DTOs.UserDto>();
    }
}
