using DataAccessLayer.Models;

namespace BusinessLogicLayer.Factories;

public interface IReportInfoFactory
{
    public ReportConfig Config { get; set; }
    ReportInfo Process();
}