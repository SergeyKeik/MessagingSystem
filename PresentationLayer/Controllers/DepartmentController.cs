using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Departments;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;
    
    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> CreateAsync()
    {
        var department = await _service.CreateDepartmentAsync();
        return Ok(department);
    }
}