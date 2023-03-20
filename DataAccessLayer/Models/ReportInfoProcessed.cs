namespace DataAccessLayer.Models;

public class ReportInfoProcessed : ReportInfo
{
    public ReportInfoProcessed(Guid id, int number)
    {
        Id = id;
        Number = number;
    }
}