using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Accounts;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost("~/Create")]
    public async Task<ActionResult<AccountDto>> CreateAsync([FromBody] CreateAccountModel model)
    {
        var account = await _service.CreateAccountAsync(model.Login, model.Password, model.Department);
        return Ok(account);
    }

    [HttpPost("~/AddSubordinate")]
    public async Task<ActionResult<AccountDto>> AddSubordinateAsync([FromBody] AddSubordinateModel model)
    {
        var subordinate = await _service.AddSubordinateAsync(model.AccountId, model.SubordinateId);

        return Ok(subordinate);
    }

}