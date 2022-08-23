using AutoMapper;
using Defender.MoneyTracking.WebUI.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Defender.MoneyTracking.Application.Modules.Home.Queries;
using Defender.MoneyTracking.Application.Enums;
using Defender.MoneyTracking.Domain.Models;

namespace Defender.MoneyTracking.WebUI.Controllers.V1;

public class HomeController : BaseApiController
{
    public HomeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet("health")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<object> HealthCheckAsync()
    {
        return new { Status = "Healthy" };
    }

    [HttpGet("authorization/check")]
    [Auth(Roles.Any)]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<object> AuthorizationCheckAsync()
    {
        return new { IsAuthorized = true };
    }

    [Auth(Roles.SuperAdmin)]
    [HttpGet("configuration")]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Dictionary<string, string>> GetConfigurationAsync(
        ConfigurationLevel configurationLevel)
    {
        var query = new GetConfigurationQuery()
        {
            Level = configurationLevel
        };

        return await ProcessApiCallWithoutMappingAsync
            <GetConfigurationQuery, Dictionary<string, string>>
            (query);
    }
}
