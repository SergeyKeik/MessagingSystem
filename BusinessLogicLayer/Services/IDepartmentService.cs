using BusinessLogicLayer.Dto;

namespace BusinessLogicLayer.Services;

public interface IDepartmentService
{
    Task<DepartmentDto> CreateDepartmentAsync();
}