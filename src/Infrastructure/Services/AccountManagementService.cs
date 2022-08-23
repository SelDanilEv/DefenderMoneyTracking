using AutoMapper;
using Defender.MoneyTracking.Application.Common.Exceptions;
using Defender.MoneyTracking.Application.Common.Interfaces;
using Defender.MoneyTracking.Application.Helpers;
using Defender.MoneyTracking.Application.Modules.Auth.Commands;
using Defender.MoneyTracking.Infrastructure.Clients.UserManagement;

namespace Defender.MoneyTracking.Infrastructure.Services;
public class AccountManagementService : IAccountManagementService
{
    private readonly IUserManagementClient _userManagementClient;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public AccountManagementService(
        IUserManagementClient userManagementClient,
        ICurrentUserService currentUserService,
        IMapper mapper)
    {
        _userManagementClient = userManagementClient;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<Application.DTOs.UserDto> UpdateUserAsync(
        UpdateAccountInfoCommand command)
    {
        var requestCommand = new UpdateAccountFromUserCommand
        {
            User = new User
            {
                Id = _currentUserService.User.Id,
                Name = command.Name,
                Email = command.Email,
            }
        };

        try
        {
            var updateResponse = await _userManagementClient.UserPUT2Async(requestCommand);
            return _mapper.Map<Application.DTOs.UserDto>(updateResponse);
        }
        catch (ApiException ex)
        {
            SimpleLogger.Log(ex);

            var message = ExceptionParser.GetValidationMessage(ex);

            throw new ExternalAPIException(message, ex);
        }
    }
}
