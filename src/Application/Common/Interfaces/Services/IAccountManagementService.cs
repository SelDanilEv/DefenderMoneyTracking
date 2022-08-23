using Defender.MoneyTracking.Application.DTOs;
using Defender.MoneyTracking.Application.Modules.Auth.Commands;

namespace Defender.MoneyTracking.Application.Common.Interfaces;

public interface IAccountManagementService
{
    Task<UserDto> UpdateUserAsync(UpdateAccountInfoCommand command);
}
