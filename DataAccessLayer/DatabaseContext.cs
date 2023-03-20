using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Telegram> Telegrams { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<MessagesNumber> MessagesNumbers { get; set; }
    public DbSet<TimespanMessagesNumber> TimespanMessagesNumbers { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<ReportInfo> ReportInfos { get; set; }
    public DbSet<ReportInfoByTime> ReportInfosByTime { get; set; }
    public DbSet<ReportInfoByDevice> ReportInfosByDevice { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(builder =>
        {
            builder.HasOne(x => x.Department);
            builder.HasMany(x => x.Subordinates).WithOne(x=> x.Supervisor);
            builder.HasMany(x => x.Devices).WithOne(x => x.Owner);
        });

        modelBuilder.Entity<Device>(builder =>
        {
            builder.HasMany(x => x.Received);
            builder.HasMany(x => x.Sent);
            builder.HasOne(x => x.Owner);
        });

        modelBuilder.Entity<Message>(builder =>
        {
            builder.HasOne(x => x.DeviceFrom).WithMany(x => x.Sent);
            builder.HasOne(x => x.DeviceTo).WithMany(x => x.Received);
        });

        modelBuilder.Entity<Department>(builder =>
        {
            builder.HasMany(x => x.Members).WithOne(x => x.Department);
        });

        modelBuilder.Entity<Report>(builder =>
        {
            builder.HasOne(x => x.Supervisor);
            builder.HasMany(x => x.ReportInfos);
        });
    }
}