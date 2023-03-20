using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Accounts;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _service;

    public DeviceController(IDeviceService service)
    {
        _service = service;
    }

    [HttpPost("~/CreatePhone")]
    public async Task<ActionResult<DeviceDto>> CreatePhoneAsync([FromBody] CreatePhoneModel model)
    {
        var device = await _service.CreatePhoneAsync(model.OwnerId);

        return Ok(device);
    }
    [HttpPost("~/CreateEmail")]
    public async Task<ActionResult<DeviceDto>> CreateEmailAsync([FromBody] CreateEmailModel model)
    {
        var device = await _service.CreateEmailAsync(model.OwnerId);

        return Ok(device);   
    }
    [HttpPost("~/CreateTelegram")]
    public async Task<ActionResult<DeviceDto>> CreateTelegramAsync([FromBody] CreateTelegramModel model)
    {
        var device = await _service.CreateTelegramAsync(model.OwnerId);

        return Ok(device);
    }

    [HttpPost("~/SendMessage")]
    public async Task<ActionResult<MessageDto>> SendMessageAsync([FromBody] CreateMessageModel model)
    {
        var message = await _service.SendMessageAsync(model.SessionId, model.Contents, model.DeviceFromId, model.DeviceToId);

        return Ok(message);
    }

    [HttpPost("~/MarkAsRead")]
    public async Task<ActionResult<MessageDto>> MarkAsRead([FromBody] ReadMessageModel model)
    {
        var message = await _service.MarkAsReadAsync(model.SessionId, model.MessageId);

        return Ok(message);
    }

    [HttpGet]
    public  Task<IReadOnlyCollection<MessageDto>> GetMessages([FromBody] GetMessagesModel model)
    {
        return _service.GetReceivedMessagesAsync(model.SessionId, model.DeviceId);
    }
}