namespace DataAccessLayer.Models;

public class Report
{
    public Report(Guid id, Account supervisor)
    {
        Id = id;
        Supervisor = supervisor;
    }
    
    protected Report() {}
    public Guid Id { get; set; }
    public virtual Account Supervisor { get; set; }
    public int ProcessedMessagesNumber { get; set; }
    public virtual ICollection<ReportInfo> ReportInfos { get; set; }

}