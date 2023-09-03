using ConsoleApp6.DbStuff;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp6;


public class MyDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }
}
