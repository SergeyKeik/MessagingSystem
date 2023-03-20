using BusinessLogicLayer.Dto;

namespace BusinessLogicLayer.Services;

public interface IReportService
{
    Task<ReportDto> CreateReportAsync(Guid sessionId, Guid accountId, DateTime beginTime, DateTime endTime);
    Task<ReportDto> GetReportAsync(Guid sessionId, Guid reportId);
}