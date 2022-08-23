using AutoMapper;
using Defender.MoneyTracking.Application.Common.Interfaces;
using Defender.MoneyTracking.Infrastructure.Clients.UserManagement;

namespace Defender.MoneyTracking.Infrastructure.Services;
public class AuthService : IAuthService
{
    private readonly IUserManagementClient _userManagementClient;
    private readonly IMapper _mapper;

    public AuthService(
        IUserManagementClient userManagementClient,
        IMapper mapper)
    {
        _userManagementClient = userManagementClient;
        _mapper = mapper;
    }

    public async Task<Application.Models.LoginResponse.LoginResponse> Authenticate(string token)
    {
        var command = new LoginGoogleCommand { Token = token };

        var loginResponse = await _userManagementClient.GoogleAsync(command);

        return _mapper.Map<Application.Models.LoginResponse.LoginResponse>(loginResponse);
    }
}
