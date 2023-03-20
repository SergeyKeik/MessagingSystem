namespace DataAccessLayer.Models;

public class Phone : Device
{
    public Phone(Guid id, Account owner)
    {
        Id = id;
        Received = new List<Message>();
        Sent = new List<Message>();
        Owner = owner;
    }
    
    protected Phone() {}
}