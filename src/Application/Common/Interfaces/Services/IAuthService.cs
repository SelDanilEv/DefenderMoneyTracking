using Defender.MoneyTracking.Application.Models.LoginResponse;

namespace Defender.MoneyTracking.Application.Common.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> Authenticate(string token);
}
