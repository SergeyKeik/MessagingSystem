namespace DataAccessLayer.Models;

public class MessagesNumber
{
    public MessagesNumber(Guid id, Guid deviceId, int number)
    {
        Id = id;
        DeviceId = deviceId;
        Number = number;
    }
    
    protected MessagesNumber() {}
    public Guid Id { get; set; }
    public Guid DeviceId { get; set; }
    public int Number { get; set; }
    
}