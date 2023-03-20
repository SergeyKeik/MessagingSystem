using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Accounts;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ReportDto>> CreateReportAsync([FromBody] CreateReportModel model)
    {
        var report = await _service.CreateReportAsync(model.SessionId, model.AccountId, model.BeginTime, model.EndTime);

        return Ok(report);
    }

    [HttpGet]
    public async Task<ActionResult<ReportDto>> GetReportAsync([FromBody] GetReportModel model)
    {
        var report = await _service.GetReportAsync(model.SessionId, model.ReportId);

        return Ok(report);
    }
}