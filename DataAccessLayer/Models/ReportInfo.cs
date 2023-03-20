namespace DataAccessLayer.Models;

public abstract class ReportInfo
{
    public Guid Id { get; set; }
    public ReportConfig Config { get; set; }
    public int Number { get; set; }
}