namespace DataAccessLayer.Models;

public class Department
{
    public Department(Guid id)
    {
        Members = new List<Account>();
        Id = id;
    }
    
    protected Department() {}
    public Guid Id { get; set; }
    public virtual ICollection<Account> Members { get; set; }
}