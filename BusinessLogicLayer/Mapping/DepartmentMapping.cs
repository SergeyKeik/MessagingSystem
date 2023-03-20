using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mapping;

public static class DepartmentMapping
{
    public static DepartmentDto AsDto(this Department department)
        => new DepartmentDto(department.Id);
}