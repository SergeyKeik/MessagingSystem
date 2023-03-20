namespace DataAccessLayer.Models;

public class Session
{
    public Session(Guid sessionId, Guid accountId)
    {
        SessionId = sessionId;
        AccountId = accountId;
    }
    
    protected Session() {}
    public Guid SessionId { get; set; }
    public Guid AccountId { get; set; }
}