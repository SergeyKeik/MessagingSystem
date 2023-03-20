namespace PresentationLayer.Models.Accounts;

public record CreateReportModel(Guid SessionId, Guid AccountId, DateTime BeginTime, DateTime EndTime);