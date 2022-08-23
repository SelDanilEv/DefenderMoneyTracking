using Defender.MoneyTracking.Domain.Entities.User;

namespace Defender.MoneyTracking.Application.Common.Interfaces;

public interface ICurrentUserService
{
    User? User { get; }
    string Token { get; }
}
