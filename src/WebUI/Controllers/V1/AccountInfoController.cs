using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Defender.MoneyTracking.Application.Modules.Auth.Commands;
using Defender.MoneyTracking.Application.DTOs;
using Defender.MoneyTracking.WebUI.Attributes;
using Defender.MoneyTracking.Domain.Models;

namespace Defender.MoneyTracking.WebUI.Controllers.V1;

public class AccountInfoController : BaseApiController
{
    public AccountInfoController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPut("update")]
    [Auth(Roles.Any)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<UserDto> UpdateAccountInfoAsync(
        [FromBody] UpdateAccountInfoCommand command)
    {
        return await ProcessApiCallWithoutMappingAsync<UpdateAccountInfoCommand, UserDto>
            (command);
    }
}
