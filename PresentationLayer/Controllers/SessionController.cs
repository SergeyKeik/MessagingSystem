using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Sessions;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionController(ISessionService service)
    {
        _service = service;
    }

    [HttpPost("~/Login")]
    public async Task<ActionResult<SessionDto>> LoginAsync([FromBody] CreateSessionModel model)
    {
        var session = await _service.LoginAsync(model.Login, model.Password);

        return Ok(session);
    }

    [HttpPost("~/Logout")]
    public async Task<ActionResult<SessionDto>> LogoutAsync([FromBody] LogoutSessionModel model)
    {
        var session = await _service.LogoutAsync(model.SessionId);

        return Ok(session);
    }
}