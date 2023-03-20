using DataAccessLayer.Models;

namespace BusinessLogicLayer.Factories;

public class ReportInfoByTimeFactory : IReportInfoFactory
{
    public ReportConfig Config { get; set; }

    public ReportInfo Process()
    {
        int numberOfMessages = 
            Config.Devices.SelectMany(device => device.Received).
                Count(message => message.Date >= Config.Begin && message.Date <= Config.End);

        return new ReportInfoByTime(Guid.NewGuid(), numberOfMessages);
    }
}