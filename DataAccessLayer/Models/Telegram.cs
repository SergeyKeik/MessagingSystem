namespace DataAccessLayer.Models;

public class Telegram : Device
{
    public Telegram(Guid id, Account owner)
    {
        Id = id;
        Received = new List<Message>();
        Sent = new List<Message>();
        Owner = owner;
    }    
    
    protected Telegram() {}
}