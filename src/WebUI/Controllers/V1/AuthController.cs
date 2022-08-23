using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Defender.MoneyTracking.Application.Models.LoginResponse;
using Defender.MoneyTracking.Application.Modules.Auth.Commands;

namespace Defender.MoneyTracking.WebUI.Controllers.V1;

public class AuthController : BaseApiController
{
    public AuthController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost("google")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<LoginResponse> GenerateJWTFromGoogleAsync(
        [FromBody] LoginGoogleCommand loginGoogleCommand)
    {
        return await ProcessApiCallWithoutMappingAsync<LoginGoogleCommand, LoginResponse>
            (loginGoogleCommand);
    }
}
