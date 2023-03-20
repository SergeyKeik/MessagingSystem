namespace DataAccessLayer.Models;

public abstract class Device
{
    public Guid Id { get; set; }
    public virtual Account Owner { get; set; }
    public virtual ICollection<Message> Received { get; set; }
    public virtual ICollection<Message> Sent { get; set; }
}