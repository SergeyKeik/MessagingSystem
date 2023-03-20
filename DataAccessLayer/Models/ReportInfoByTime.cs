using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccessLayer.Models;

public class ReportInfoByTime : ReportInfo
{
    public ReportInfoByTime(Guid id, int number)
    {
        Id = id;
        Number = number;
    }
    
}