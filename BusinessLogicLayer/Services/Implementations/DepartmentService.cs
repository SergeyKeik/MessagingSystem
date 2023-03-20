using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services.Implementations;

public class DepartmentService : IDepartmentService
{
    private readonly DatabaseContext _context;

    public DepartmentService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<DepartmentDto> CreateDepartmentAsync()
    {
        var department = new Department(Guid.NewGuid());
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department.AsDto();
    }
    
}