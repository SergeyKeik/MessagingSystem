namespace DataAccessLayer.Models;

public class Message
{
    public Message(Guid id, string contents, Device deviceFrom, Device deviceTo, DateTime date)
    {
        Id = id;
        MessageStatus = Status.New;
        Contents = contents;
        Processed = false;
        DeviceFrom = deviceFrom;
        DeviceTo = deviceTo;
        Date = date;

    }
    
    protected Message() {}
    public enum Status
    {
        New,
        Received,
        Read
    }
    public Guid Id { get; set; }
    public Status MessageStatus { get; set; }
    public string Contents { get; set; }
    public bool Processed { get; set; }
    public virtual Device DeviceFrom { get; set; }
    public virtual Device DeviceTo { get; set; }
    public DateTime Date { get; set; }
}