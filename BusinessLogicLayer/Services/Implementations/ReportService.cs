using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Exceptions.AuthorizationException;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Factories;
using BusinessLogicLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services.Implementations;

public class ReportService : IReportService
{
    private readonly DatabaseContext _context;
    private ICollection<IReportInfoFactory> _factories;

    public ReportService(DatabaseContext context, ICollection<IReportInfoFactory> factories)
    {
        _context = context;
        _factories = factories;
    }

    public async Task<ReportDto> CreateReportAsync(Guid sessionId, Guid accountId, DateTime beginTime, DateTime endTime)
    {
        var session = await _context.Sessions.GetEntityAsync(sessionId);
        if (session.AccountId != accountId)
        {
            throw new OperationIsNotAuthorizedException("No access to this account");
        }

        var config = new ReportConfig(beginTime, endTime);
        var account = await _context.Accounts.GetEntityAsync(accountId);
        var report = new Report(Guid.NewGuid(), account);
        ICollection<Device> devices = account.Subordinates.SelectMany(subordinate => subordinate.Devices).ToList();
        config.Devices = devices;
        foreach (var factory in _factories)
        {
            factory.Config = config;
        }

        ICollection<ReportInfo> reportInfos = _factories.Select(factory => factory.Process()).ToList();

        foreach (var reportInfo in reportInfos)
        {
            _context.ReportInfos.Add(reportInfo);
            report.ReportInfos.Add(reportInfo);
        }

        _context.Add(report);

        await _context.SaveChangesAsync();
        return report.AsDto();
    }

    public async Task<ReportDto> GetReportAsync(Guid sessionId, Guid reportId)
    {
        var session = await _context.Sessions.GetEntityAsync(sessionId);
        var report = await _context.Reports.GetEntityAsync(reportId);
        if (session.AccountId != report.Supervisor.Id)
        {
            throw new OperationIsNotAuthorizedException("No access to this report");
        }

        return report.AsDto();
    }
}