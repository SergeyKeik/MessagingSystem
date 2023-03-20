namespace DataAccessLayer.Models;

public class ReportInfoByDevice : ReportInfo
{
    public ReportInfoByDevice(Guid id, int number)
    {
        Id = id;
        Number = number;
    }
}