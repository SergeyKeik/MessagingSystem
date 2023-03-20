namespace DataAccessLayer.Models;

public class ReportConfig
{
    public ReportConfig(DateTime begin, DateTime end)
    {
        Begin = begin;
        End = end;
    }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public ICollection<Device> Devices { get; set; } 
}