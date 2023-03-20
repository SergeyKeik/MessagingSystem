namespace DataAccessLayer.Models;

public class TimespanMessagesNumber
{
    public TimespanMessagesNumber(Guid id, DateTime begin, DateTime end, int number)
    {
        Id = id;
        Begin = begin;
        End = end;
        Number = number;
    }
    
    protected TimespanMessagesNumber() {}
    public Guid Id { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public int Number { get; set; }
}