namespace DataAccessLayer.Models;

public class Account
{
    public Account(Guid id, string login, string password, Department department)
    {
        Id = id;
        Login = login;
        Password = password;
        Department = department;
        Subordinates = new List<Account>();
    }

    protected Account() {}
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Account> Subordinates { get; set; }
    public virtual Account? Supervisor { get; set; }
    public virtual ICollection<Device> Devices { get; set; }
    public virtual Department Department { get; set; }
}