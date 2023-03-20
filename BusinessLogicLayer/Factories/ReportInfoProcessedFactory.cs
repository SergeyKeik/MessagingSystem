using DataAccessLayer.Models;

namespace BusinessLogicLayer.Factories;

public class ReportInfoProcessedFactory : IReportInfoFactory
{
    public ReportConfig Config { get; set; }
    public ReportInfo Process()
    {
        int numberOfMessages = Config.Devices.SelectMany(device => device.Received).Count(message => message.Processed);

        return new ReportInfoProcessed(Guid.NewGuid(), numberOfMessages);
    }
}