using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mapping;

public static class ReportMapping
{
    public static ReportDto AsDto(this Report report)
        => new ReportDto(
            report.Id,
            report.Supervisor.Id,
            report.ReportInfos.Select(x => x.Id));
}