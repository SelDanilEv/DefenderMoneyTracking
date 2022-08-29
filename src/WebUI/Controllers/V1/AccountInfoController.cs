using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Defender.MoneyTracking.Application.Models.LoginResponse;
using Defender.MoneyTracking.Application.Modules.Auth.Commands;
using Defender.MoneyTracking.Application.DTOs;

namespace Defender.MoneyTracking.WebUI.Controllers.V1;

public class AccountInfoController : BaseApiController
{
    public AccountInfoController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPut("update")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<UserDto> UpdateAccountInfoAsync(
        [FromBody] UpdateAccountInfoCommand command)
    {
        return await ProcessApiCallWithoutMappingAsync<UpdateAccountInfoCommand, UserDto>
            (command);
    }
}
