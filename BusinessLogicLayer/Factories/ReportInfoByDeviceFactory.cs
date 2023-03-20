using DataAccessLayer.Models;

namespace BusinessLogicLayer.Factories;

public class ReportInfoByDeviceFactory : IReportInfoFactory
{
    public ReportConfig Config { get; set; }
    public ReportInfo Process()
    {
        int numberOfMessages = Config.Devices.Sum(device => device.Received.Count);
        return new ReportInfoByDevice(Guid.NewGuid(), numberOfMessages);
    }
}