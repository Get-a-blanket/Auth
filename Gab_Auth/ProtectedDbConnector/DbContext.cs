using GaB_Auth.DbConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace GaB_Auth.DbConnector;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(GaB_Auth.ConfigurationManager.ConnectionStringProtectedDb);
    }
}