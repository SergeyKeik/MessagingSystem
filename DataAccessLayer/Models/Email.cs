namespace DataAccessLayer.Models;

public class Email : Device
{
    public Email(Guid id, Account owner)
    {
        Id = id;
        Received = new List<Message>();
        Sent = new List<Message>();
        Owner = owner;
    }
    
    protected Email() {}
}